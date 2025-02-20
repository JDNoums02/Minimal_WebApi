using Microsoft.EntityFrameworkCore;
using TP4.Models;

namespace TP4
{
    public class ApplicationDbContext(DbContextOptions options):DbContext(options)
    {
       public DbSet<Trajet> Trajets { get; set; } = null;
      public  DbSet<Arret> Arrets { get; set; } = null;
       public DbSet<Chauffeur> Chauffeurs { get; set; } = null;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trajet>().HasMany(x => x.PointsArret).WithOne(x => x.Trajet).
             OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Trajet>().HasMany(x => x.ChauffeursFormes).WithMany(x => x.TrajetsFormationRecue);    
        }
        
    }
}
