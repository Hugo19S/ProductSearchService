using ErrorOr;
using MediatR;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.Products.Queries.GetProducts
{
    public record GetProductsQuery() : IRequest<ErrorOr<List<Product>>>;

    public class GetProductsQueryHandler(IProductRepository repository) : IRequestHandler<GetProductsQuery, ErrorOr<List<Product>>>
    {
        public async Task<ErrorOr<List<Product>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetProducts(cancellationToken);
        }
    }
}
