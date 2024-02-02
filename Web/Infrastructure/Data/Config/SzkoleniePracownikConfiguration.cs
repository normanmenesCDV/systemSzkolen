using Domain.SzkolenieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class SzkoleniePracownikConfiguration : IEntityTypeConfiguration<SzkoleniePracownik>
    {
        public void Configure(EntityTypeBuilder<SzkoleniePracownik> builder)
        {
            builder.HasKey(x => new { x.SzkolenieId, x.PracownikId });

            builder
                .HasOne(x => x.Szkolenie)
                .WithMany(x => x.SzkoleniaPracownicy)
                .HasForeignKey(x => x.SzkolenieId)
                .IsRequired();

            builder
                .HasOne(x => x.Pracownik)
                .WithMany(x => x.SzkoleniaPracownicy)
                .HasForeignKey(x => x.PracownikId)
                .IsRequired();
        }
    }
}
