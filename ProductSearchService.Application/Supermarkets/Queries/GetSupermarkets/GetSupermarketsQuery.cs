using ErrorOr;
using MediatR;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.Supermarkets.Queries.GetSupermarkets
{
    
    public record GetSupermarketsQuery() : IRequest<ErrorOr<List<Supermarket>>>;

    public class GetSupermarketsQueryHandler(ISupermarketRepository repository) : IRequestHandler<GetSupermarketsQuery, ErrorOr<List<Supermarket>>>
    {
        public async Task<ErrorOr<List<Supermarket>>> Handle(GetSupermarketsQuery request, CancellationToken cancellationToken)
        {
            return await repository.GetSupermarkets(cancellationToken);
        }
    }
}
