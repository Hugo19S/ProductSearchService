namespace ProductSearchService.Domain;

public class SupermarketProduct
{
    public Guid ProductId { get; set; }
    public Guid SupermarketId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int ProductQuantity { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public Product? Product { get; set; }
    public Supermarket? Supermarket { get; set; }
}