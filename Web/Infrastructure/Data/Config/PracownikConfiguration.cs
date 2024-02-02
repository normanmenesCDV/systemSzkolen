using Domain.PracownikAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class PracownikConfiguration : IEntityTypeConfiguration<Pracownik>
    {
        public void Configure(EntityTypeBuilder<Pracownik> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Guid);
            builder.Property(x => x.Guid).HasDefaultValueSql("newsequentialid()");

            builder.Property(x => x.Imie).HasMaxLength(255);
            builder.Property(x => x.Nazwisko).HasMaxLength(255);
            builder.Property(x => x.PESEL).HasMaxLength(11);
        }
    }
}
