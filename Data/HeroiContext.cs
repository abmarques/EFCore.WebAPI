using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore.WebAPI.Data {
  public class HeroiContext : DbContext {

    public DbSet<Heroi> Herois { get; set; }
    public DbSet<Batalha> Batalhas { get; set; }
    public DbSet<Arma> Armas { get; set; }
    public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }
    public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlServer(@"Password=Root1526;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=.\SQLEXPRESS");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<HeroiBatalha>(entity => {
        entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
      });
    }
  }
}
