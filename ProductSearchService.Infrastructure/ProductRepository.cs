using ErrorOr;
using Microsoft.EntityFrameworkCore;
using ProductSearchService.Application;
using ProductSearchService.Application.Products.Exceptions;
using ProductSearchService.Domain;

namespace ProductSearchService.Infrastructure;

public class ProductRepository(AppDbContext dbContext) : IProductRepository
{
    public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
    {
        return await dbContext.Products.ToListAsync(cancellationToken);
    }

    public async Task<Product?> GetProductById(Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Products
            .Include(p => p.SupermarketProducts)
            .ThenInclude(sp => sp.Supermarket)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<ErrorOr<Created>> AddProduct(Product product, CancellationToken cancellationToken)
    {
        Product? existingProduct = await dbContext.Products.FirstOrDefaultAsync(p => p.Name == product.Name, cancellationToken);

        if (existingProduct != null)
        {
            return Error.Conflict("Product.Conflict", new ProductConflictException(product.Name).Message);
        }

        try
        {
            await dbContext.Products.AddAsync(product, cancellationToken);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("unique constraint") ?? false)
        {
            return Error.Conflict("Product.Conflict", $"Produto com nome {product.Name} já existe.");
        }
        catch (Exception)
        {
            return Error.Failure("Product.Failure", "An unexpected error occurred while adding the product.");
        }

        return new Created();
    }

    public async Task UpdateProduct(Product product, CancellationToken cancellationToken)
    {
        await dbContext.Products
            .Where(p => p.Id == product.Id)
            .ExecuteUpdateAsync(x => x
                    .SetProperty(o => o.Name, product.Name)
                    .SetProperty(o => o.Barcode, product.Barcode)
                    .SetProperty(o => o.Image, product.Image), cancellationToken) ;
    }

    public async Task DeleteProduct(Product product, CancellationToken ct)
    {
        await dbContext.Products.Where(p => p.Id == product.Id).ExecuteDeleteAsync(ct);
    }
}