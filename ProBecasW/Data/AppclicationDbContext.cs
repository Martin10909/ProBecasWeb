
using Microsoft.EntityFrameworkCore;
using ProBecasW.Models;
using ProBecasW.Models;

namespace ProBecasW.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<SolicitudBeca> SolicitudesBeca { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolicitudBeca>().ToTable("SolicitudesBeca");
        }
    }
}
