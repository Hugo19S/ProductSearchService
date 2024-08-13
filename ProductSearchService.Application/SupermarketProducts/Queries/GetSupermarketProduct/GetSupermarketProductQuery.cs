using ErrorOr;
using MediatR;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.SupermarketProducts.Queries.GetSupermarketProduct;

public record GetSupermarketProductQuery(
    Guid SupermarketId, Guid ProductId) : IRequest<ErrorOr<SupermarketProduct>>;

public class GetSupermarketProductQueryHandler(
    ISupermarketProductRepository repository
    ) : IRequestHandler<GetSupermarketProductQuery, ErrorOr<SupermarketProduct>>
{
    public async Task<ErrorOr<SupermarketProduct>> Handle(
        GetSupermarketProductQuery request, CancellationToken cancellationToken)
    {
        var productSearch = await repository
            .GetSupermarketProductById(request.SupermarketId, request.ProductId, cancellationToken);

        if (productSearch == null) return Error.NotFound("SupermarketProduct.NotFound", 
                                                         $"Product with id {request.ProductId} does not exist in the Supermarket with id {request.SupermarketId}.");

        return productSearch;
    }
}
