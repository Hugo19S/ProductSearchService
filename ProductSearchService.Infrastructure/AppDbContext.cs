using Microsoft.EntityFrameworkCore;
using ProductSearchService.Application.Common;
using ProductSearchService.Domain;
using System.Reflection;

namespace ProductSearchService.Infrastructure;

public class AppDbContext : DbContext, IUnitOfWork
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supermarket> Supermarket { get; set; }
    public DbSet<SupermarketProduct> SupermarketProduct { get; set; }
    public DbSet<PendingNotification> PendingNotification { get; set; }

    public AppDbContext()
    { }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(@"Server=localhost;Port=5432;Database=Supermarket;User Id=postgres;Password=hugo;");
            base.OnConfiguring(optionsBuilder);
        }
    }

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Supermarket>()
            .HasMany(e => e.Products)
            .WithMany(e => e.Supermarkets)
            .UsingEntity<SupermarketProduct>();

        modelBuilder.Entity<Supermarket>()
            .HasData(
                new { Id = Guid.Parse("34d678a1-ade5-4f3c-8b4c-bf92a78a1234"), Name = "Continente" },
                new { Id = Guid.Parse("34e60c09-7b61-4cb4-97e3-0bd03f02f80b"), Name = "Pingo Doce" },
                new { Id = Guid.Parse("0149b95c-2857-445f-a0dd-16d591278e46"), Name = "Lidl" },
                new { Id = Guid.Parse("1aaa883e-2b3d-4b0b-bad2-f696431067e2"), Name = "Auchan" },
                new { Id = Guid.Parse("e4a32804-3206-48dc-8dcd-a455480bac2c"), Name = "Intermarché" },
                new { Id = Guid.Parse("a670b084-ae63-48c9-b248-7b997beaf486"), Name = "Minipreço" },
                new { Id = Guid.Parse("90c8513a-181c-4abd-a855-9864ecc044d8"), Name = "Aldi" },
                new { Id = Guid.Parse("da98f9aa-afd6-444f-a3dd-92b7ab32cf5d"), Name = "Mercadona" }
            );

        modelBuilder.Entity<Product>()
            .HasData(
                new { Id = Guid.Parse("3657192b-8bf1-41cc-aa7e-27fb13b0542c"), Name = "Shampoo Hidratante", Barcode = "WAUSH78E87A574664" },
                new { Id = Guid.Parse("a6528c65-5d6d-4560-ad59-70703ed98e45"), Name = "Condicionador Nutritivo", Barcode = "1G6AS5S32F0858696" },
                new { Id = Guid.Parse("8cea0461-31a2-4146-a936-cc881f97eeab"), Name = "Creme para Pentear", Barcode = "4A31K5DFXAE659389" },
                new { Id = Guid.Parse("11d951a4-d47d-4493-a65e-37edabf8f488"), Name = "Gel Fixador", Barcode = "3C63D3DL8CG122197" },
                new { Id = Guid.Parse("f846a46b-64a3-4fb9-b88b-9e1da3b25fa7"), Name = "Mousse Modelador", Barcode = "1N6AF0LYXFN674122" },
                new { Id = Guid.Parse("56aae860-62f1-420e-8449-2d62df55a6e4"), Name = "Óleo Reparador", Barcode = "JM3KE2BE6F0509041" },
                new { Id = Guid.Parse("eabc1500-7d32-488b-9051-c062c9b23ad0"), Name = "Serum Anti-Frizz", Barcode = "WAUBFAFL7CN345965" },
                new { Id = Guid.Parse("97ecdc35-621e-46fd-a280-f34e00ce3340"), Name = "Máscara Capilar", Barcode = "SCBDR33WX9C881684" },
                new { Id = Guid.Parse("2c82cde0-f5c8-408b-8959-9b2ddd61618d"), Name = "Tônico Capilar", Barcode = "WP0CB2A81FK737485" },
                new { Id = Guid.Parse("42f7d306-4435-4d84-abce-ace14095800b"), Name = "Leave-in Condicionante", Barcode = "2C3CDXJG5CH817619" }
            );

        modelBuilder.Entity<SupermarketProduct>()
        .HasData(
                new
                {
                    SupermarketId = Guid.Parse("34d678a1-ade5-4f3c-8b4c-bf92a78a1234"),
                    ProductId = Guid.Parse("3657192b-8bf1-41cc-aa7e-27fb13b0542c"),
                    Price = 4.99M,
                    Description = "Shampoo Hidratante - Continente",
                    ProductQuantity = 100,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("34e60c09-7b61-4cb4-97e3-0bd03f02f80b"),
                    ProductId = Guid.Parse("a6528c65-5d6d-4560-ad59-70703ed98e45"),
                    Price = 5.99M,
                    Description = "Condicionador Nutritivo - Pingo Doce",
                    ProductQuantity = 150,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("0149b95c-2857-445f-a0dd-16d591278e46"),
                    ProductId = Guid.Parse("8cea0461-31a2-4146-a936-cc881f97eeab"),
                    Price = 3.99M,
                    Description = "Creme para Pentear - Lidl",
                    ProductQuantity = 200,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("1aaa883e-2b3d-4b0b-bad2-f696431067e2"),
                    ProductId = Guid.Parse("11d951a4-d47d-4493-a65e-37edabf8f488"),
                    Price = 6.49M,
                    Description = "Gel Fixador - Auchan",
                    ProductQuantity = 80,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("e4a32804-3206-48dc-8dcd-a455480bac2c"),
                    ProductId = Guid.Parse("f846a46b-64a3-4fb9-b88b-9e1da3b25fa7"),
                    Price = 7.99M,
                    Description = "Mousse Modelador - Intermarché",
                    ProductQuantity = 120,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("a670b084-ae63-48c9-b248-7b997beaf486"),
                    ProductId = Guid.Parse("56aae860-62f1-420e-8449-2d62df55a6e4"),
                    Price = 9.99M,
                    Description = "Óleo Reparador - Minipreço",
                    ProductQuantity = 60,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("90c8513a-181c-4abd-a855-9864ecc044d8"),
                    ProductId = Guid.Parse("eabc1500-7d32-488b-9051-c062c9b23ad0"),
                    Price = 12.99M,
                    Description = "Serum Anti-Frizz - Aldi",
                    ProductQuantity = 90,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("da98f9aa-afd6-444f-a3dd-92b7ab32cf5d"),
                    ProductId = Guid.Parse("97ecdc35-621e-46fd-a280-f34e00ce3340"),
                    Price = 14.99M,
                    Description = "Máscara Capilar - El Corte Inglés",
                    ProductQuantity = 110,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("34d678a1-ade5-4f3c-8b4c-bf92a78a1234"),
                    ProductId = Guid.Parse("2c82cde0-f5c8-408b-8959-9b2ddd61618d"),
                    Price = 6.99M,
                    Description = "Tônico Capilar - E.Leclerc",
                    ProductQuantity = 130,
                    CreatedOn = DateTime.UtcNow
                },
                new
                {
                    SupermarketId = Guid.Parse("34e60c09-7b61-4cb4-97e3-0bd03f02f80b"),
                    ProductId = Guid.Parse("42f7d306-4435-4d84-abce-ace14095800b"),
                    Price = 11.99M,
                    Description = "Leave-in Condicionante - Mercadona",
                    ProductQuantity = 140,
                    CreatedOn = DateTime.UtcNow
                }
            );
        base.OnModelCreating(modelBuilder);
    }
}
