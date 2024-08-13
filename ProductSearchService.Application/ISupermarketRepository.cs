using ErrorOr;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application;

public interface ISupermarketRepository
{
    Task<ErrorOr<Created>> AddSupermarket(Supermarket supermarket, CancellationToken ct);
    Task<List<Supermarket>> GetSupermarkets(CancellationToken ct);
    Task<Supermarket?> GetSupermarketById(Guid id, CancellationToken ct);
    Task DeleteSupermarket(Supermarket supermarket, CancellationToken ct);
    Task UpdateSupermarket(Supermarket supermarket, CancellationToken ct);
}
