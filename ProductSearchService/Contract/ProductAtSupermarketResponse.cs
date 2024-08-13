using ProductSearchService.Domain;

namespace ProductSearchService.WebApi.Contract
{
    public class ProductWithDetailsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string? Image { get; set; }
        public List<ProductAtSupermarketResponse> SupermarketProducts { get; } = [];

    }

    public class ProductAtSupermarketRequest
    {
        public Guid SupermarketId { get; set; }
        public Guid ProductId { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int ProductQuantity {  get; set; }
    }
    public class ProductAtSupermarketResponse
    {
        public Guid SupermarketId { get; set; }
        public Guid ProductId { get; set; }
        public string Supermarket { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ProductQuantity {  get; set; }
    }

    public class SupermarketWithDetailsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SupermarketWithProductResponse> SupermarketProducts { get; } = [];

    }

    public class SupermarketWithProductResponse
    {
        public string ProductId { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ProductQuantity { get; set; }
    }
}
