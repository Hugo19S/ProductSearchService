using ErrorOr;
using ProductSearchService.Domain;

namespace ProductSearchService.Application;

public interface IProductRepository
{
    Task<ErrorOr<Created>> AddProduct(Product product, CancellationToken ct);
    Task<List<Product>> GetProducts(CancellationToken ct);
    Task<Product?> GetProductById(Guid id, CancellationToken ct);
    Task DeleteProduct(Product product, CancellationToken ct);
    Task UpdateProduct(Product product, CancellationToken ct);
}
