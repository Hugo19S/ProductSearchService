using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSearchService.Domain;

namespace ProductSearchService.Infrastructure.Configurations;

public class SupermarketEntityConfiguration : IEntityTypeConfiguration<Supermarket>
{
    public void Configure(EntityTypeBuilder<Supermarket> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
    }
}
