using System.Text.Json.Serialization;

namespace net_il_mio_fotoalbum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // this setting helps in avoiding infinite loops during JSON serialization when there are circular references in your data structures, which is a common scenario when you have related entities in your models. (N:N, 1:N relationships)
            builder.Services.AddControllers().AddJsonOptions(x =>
                            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // configure the routing system to be aware of and handle Razor Pages. Razor Pages is a feature of ASP.NET Core that makes coding page-focused scenarios easier and more productive.
            app.MapRazorPages();

            app.Run();
        }
    }
}