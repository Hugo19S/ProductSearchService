using ErrorOr;
using MediatR;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.Supermarkets.Queries.GetSupermarket;

public record GetSupermarketQuery(Guid Id) : IRequest<ErrorOr<Supermarket>>;

public class GetSupermarketQueryHandler(ISupermarketRepository repository) : IRequestHandler<GetSupermarketQuery, ErrorOr<Supermarket>>
{
    public async Task<ErrorOr<Supermarket>> Handle(GetSupermarketQuery request, CancellationToken cancellationToken)
    {
        var supermarket = await repository.GetSupermarketById(request.Id, cancellationToken);

        if (supermarket == null) 
        {
            return Error.NotFound("Supermarket.NotFound", $"Supermarket with id {request.Id} does not exist.");
        }

        return supermarket;
    }
}
