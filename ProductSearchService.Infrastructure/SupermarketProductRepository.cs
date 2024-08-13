using Microsoft.EntityFrameworkCore;
using ProductSearchService.Application;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Infrastructure
{
    public class SupermarketProductRepository(AppDbContext dbContext) : ISupermarketProductRepository
    {
        public async Task AddSupermarketProduct(SupermarketProduct supermarketProduct, CancellationToken ct)
        {
            await dbContext.AddAsync(supermarketProduct, ct);
        }

        public async Task DeleteSupermarketProduct(SupermarketProduct supermarketProduct, CancellationToken ct)
        {
            await dbContext.SupermarketProduct
                .Where(x => x.SupermarketId == supermarketProduct.SupermarketId && 
                            x.ProductId == supermarketProduct.ProductId)
                .ExecuteDeleteAsync(ct);
        }

        public async Task<SupermarketProduct?> GetSupermarketProductById(Guid supermarketId, Guid productId, CancellationToken ct)
        {
            return await dbContext.SupermarketProduct.FirstOrDefaultAsync(x => x.SupermarketId == supermarketId && x.ProductId == productId);
        }

        public async Task<List<SupermarketProduct>> GetSupermarketProducts(CancellationToken ct)
        {
            return await dbContext.SupermarketProduct.ToListAsync(ct);
        }

        public async Task UpdateSupermarketProduct(SupermarketProduct supermarketProduct, CancellationToken ct)
        {
            await dbContext.SupermarketProduct
                .Where(x => x.ProductId == supermarketProduct.ProductId && 
                            x.SupermarketId == supermarketProduct.SupermarketId)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(price => price.Price, supermarketProduct.Price)
                    .SetProperty(description => description.Description, supermarketProduct.Description)
                    .SetProperty(quantity => quantity.ProductQuantity, supermarketProduct.ProductQuantity), 
                cancellationToken: ct);
        }
    }
}