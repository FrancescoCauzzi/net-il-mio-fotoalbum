using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Database;
using net_il_mio_fotoalbum.Models;
using net_il_mio_fotoalbum.Models.DatabaseModels;

namespace net_il_mio_fotoalbum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<FotoAlbumContext>();

            //var connectionString = builder.Configuration.GetConnectionString("FotoAlbumContextConnection") ?? throw new InvalidOperationException("Connection string 'FotoAlbumContextConnection' not found.");


            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                                .AddEntityFrameworkStores<FotoAlbumContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // this setting helps in avoiding infinite loops during JSON serialization when there are circular references in your data structures, which is a common scenario when you have related entities in your models. (N:N, 1:N relationships)
            builder.Services.AddControllers().AddJsonOptions(x =>
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            // DEPENDENCY INJECTIONS
            // DI for the database
            builder.Services.AddScoped<FotoAlbumContext, FotoAlbumContext>();

            // DI repository pattern Picture
            builder.Services.AddScoped<IRepository<Picture, PictureFormModel>, RepositoryPicture>();
            // DI repository pattern Category
            builder.Services.AddScoped<IRepository<Category, CategoryFormModel>, RepositoryCategory>();
            // DI repository pattern Contact
            builder.Services.AddScoped<IRepository<Contact, ContactFormModel>, RepositoryContact>();



            // Add CORS policy to avoid error messages in cross-origin requests when communicating with a front-end app
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:5173")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod()
                                      );
            });

            // DEPENDENCY INJECTIONS Above

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // authentication line in our setup, REMEMBER !!!
            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // configure the routing system to be aware of and handle Razor Pages. Razor Pages is a feature of ASP.NET Core that makes coding page-focused scenarios easier and more productive.
            app.MapRazorPages();

            // Apply the CORS policy
            app.UseCors("AllowSpecificOrigin");


            app.Run();
        }
    }
}