using ErrorOr;
using Microsoft.EntityFrameworkCore;
using ProductSearchService.Application;
using ProductSearchService.Application.Supermarkets.Exceptions;
using ProductSearchService.Domain;

namespace ProductSearchService.Infrastructure;

public class SupermarketRepository(AppDbContext dbContext) : ISupermarketRepository
{
    public async Task<ErrorOr<Created>> AddSupermarket(Supermarket supermarket, CancellationToken cancellationToken)
    {
        var supermarketAdded = await dbContext.Supermarket.FirstOrDefaultAsync(x => x.Name == supermarket.Name, cancellationToken);

        if (supermarketAdded != null) 
        {
            return Error.Conflict("Supermarket.Conflict", new SupermarketConflictException(supermarket.Name).Message);
        }

        try
        {
            await dbContext.Supermarket.AddAsync(supermarket, cancellationToken);
        }
        catch (Exception)
        {
            return Error.Failure("Product.Failure", "An unexpected error occurred while adding the product.");
        }

        return new Created();
        
    }

    public async Task DeleteSupermarket(Supermarket supermarket, CancellationToken ct)
    {
        await dbContext.Supermarket.Where(x => x.Id == supermarket.Id).ExecuteDeleteAsync(ct);
    }

    public async Task<Supermarket?> GetSupermarketById(Guid id, CancellationToken ct)
    {
        return await dbContext.Supermarket
            .Include(x => x.SupermarketProducts)
            .ThenInclude(x => x.Product)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task<List<Supermarket>> GetSupermarkets(CancellationToken ct)
    {
        return await dbContext.Supermarket.ToListAsync(ct);
    }

    public async Task UpdateSupermarket(Supermarket supermarket, CancellationToken ct)
    {
        await dbContext.Supermarket
             .Where(x => x.Id == supermarket.Id)
             .ExecuteUpdateAsync(setters => setters
                    .SetProperty(name => name.Name, supermarket.Name), ct);
    }
}
