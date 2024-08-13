using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSearchService.Domain;

namespace ProductSearchService.Infrastructure.Configurations;

public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //builder.HasKey(x => new
        //{
        //    x.Id,
        //    x.Name,
        //});

        builder.Property(p => p.Name).HasMaxLength(150).IsRequired();
        builder.HasIndex(p => p.Name).IsUnique();
        builder.Property(p => p.Barcode).HasMaxLength(25).IsRequired();
    }
}
