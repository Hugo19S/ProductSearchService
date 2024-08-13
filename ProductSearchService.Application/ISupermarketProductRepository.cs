using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application;

public interface ISupermarketProductRepository
{
    Task AddSupermarketProduct(SupermarketProduct supermarketProduct, CancellationToken ct);
    Task<List<SupermarketProduct>> GetSupermarketProducts(CancellationToken ct);
    Task<SupermarketProduct?> GetSupermarketProductById(Guid supermarketId, Guid productId, CancellationToken ct);
    Task DeleteSupermarketProduct(SupermarketProduct supermarketProduct, CancellationToken ct);
    Task UpdateSupermarketProduct(SupermarketProduct supermarketProduct, CancellationToken ct);
}
