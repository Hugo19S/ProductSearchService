using ErrorOr;
using MediatR;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.SupermarketProducts.Queries.GetSupermarketsProducts
{
    public record GetSupermarketsProductsQuerry() : IRequest<ErrorOr<List<SupermarketProduct>>>;

    public class GetSupermarketsProductsQuerryHandler(ISupermarketProductRepository repository) : IRequestHandler<GetSupermarketsProductsQuerry, ErrorOr<List<SupermarketProduct>>>
    {
        public async Task<ErrorOr<List<SupermarketProduct>>> Handle(GetSupermarketsProductsQuerry request, CancellationToken cancellationToken)
        {
            return await repository.GetSupermarketProducts(cancellationToken);
        }
    }
}
