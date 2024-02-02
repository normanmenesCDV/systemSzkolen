using System.Reflection;
using Domain.PracownikAggregate;
using Domain.SzkolenieAggregate;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class Model : DbContext
    {
        public Model()
            : base() { }

        public Model(DbContextOptions<Model> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Szkolenie> Szkolenia { get; set; }
        public DbSet<SzkoleniePracownik> SzkoleniaPracownicy { get; set; }
    }
}
