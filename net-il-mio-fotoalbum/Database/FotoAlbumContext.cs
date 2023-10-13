using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models.DatabaseModels;

namespace net_il_mio_fotoalbum.Database
{
    public class FotoAlbumContext : IdentityDbContext<IdentityUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=MVC_EF_FotoAlbum;" +
            "Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<Picture> Pictures { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Contact> Contacts { get; set; }
    }
}
