using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductSearchService.Domain;

namespace ProductSearchService.Infrastructure.Configurations;

internal class SupermarketProductConfiguration : IEntityTypeConfiguration<SupermarketProduct>
{
    public void Configure(EntityTypeBuilder<SupermarketProduct> builder)
    {
        builder.Property(p => p.ProductId).IsRequired();
        builder.Property(p => p.SupermarketId).IsRequired();
        builder.Property(p => p.Price).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.ProductQuantity).IsRequired();
        builder.Property(p => p.CreatedOn).HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}
