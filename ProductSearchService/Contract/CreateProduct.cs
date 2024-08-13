
namespace ProductSearchService.WebApi.Contract;

public class CreateProductRequest
{
    public string Name { get; set; } = string.Empty;
    public string Barcode { get; set; } = string.Empty;
    public string? Image { get; set; }
}

public class ProductResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Barcode { get; set; }
    public string Image { get; set; }
}
