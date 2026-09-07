using Bibliotheques.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
namespace Bibliotheques.Infrastructure.Data;
public class BibliothequeDbContext : DbContext {
    public BibliothequeDbContext(DbContextOptions<BibliothequeDbContext> options):base(options){}
    public DbSet<Livre> Livres => Set<Livre>();
    public DbSet<Usager> Usagers => Set<Usager>();
    public DbSet<Emprunt> Emprunts => Set<Emprunt>();
    public DbSet<Exemplaire> Exemplaires => Set<Exemplaire>();
    protected override void OnModelCreating(ModelBuilder b) {
        b.Entity<Livre>().ToTable("Livres"); b.Entity<Usager>().ToTable("Usagers"); b.Entity<Emprunt>().ToTable("Emprunts"); b.Entity<Exemplaire>().ToTable("Exemplaires");
        b.Entity<Usager>().HasKey(x=>x.NoAbonne);
        b.Entity<Emprunt>().HasOne(x=>x.Livre).WithMany(x=>x.Emprunts).HasForeignKey(x=>x.LivreId).OnDelete(DeleteBehavior.Cascade);
        b.Entity<Emprunt>().HasOne(x=>x.Usager).WithMany(x=>x.Emprunts).HasForeignKey(x=>x.UsagerNoAbonne).OnDelete(DeleteBehavior.Cascade);
        b.Entity<Emprunt>().HasOne(x=>x.Exemplaire).WithMany(x=>x.Emprunts).HasForeignKey(x=>x.ExemplaireId).OnDelete(DeleteBehavior.SetNull);
        b.Entity<Exemplaire>().HasOne(x=>x.Livre).WithMany(x=>x.Exemplaires).HasForeignKey(x=>x.LivreId).OnDelete(DeleteBehavior.SetNull);
    }
}
