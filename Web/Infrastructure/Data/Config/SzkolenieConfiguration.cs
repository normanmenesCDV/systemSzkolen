using Domain.SzkolenieAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    internal class SzkolenieConfiguration : IEntityTypeConfiguration<Szkolenie>
    {
        public void Configure(EntityTypeBuilder<Szkolenie> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Guid);
            builder.Property(x => x.Guid).HasDefaultValueSql("newsequentialid()");

            builder.Property(x => x.Nazwa).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Organizator).HasMaxLength(500);
        }
    }
}
