
namespace ProductSearchService.WebApi.Contract;

public class UpdateProductRequest
{
    public string? Name { get; set; }
    public string? Barcode { get; set; }
    public string? Image { get; set; }
}
