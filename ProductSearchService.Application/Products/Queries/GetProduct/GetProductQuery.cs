using ErrorOr;
using MediatR;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.Products.Queries.GetProduct;

public record GetProductQuery(Guid Id) : IRequest<ErrorOr<Product>>;

public class GetProductQueryHandler(IProductRepository repository) : IRequestHandler<GetProductQuery, ErrorOr<Product>>
{
    public async Task<ErrorOr<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        var product = await repository.GetProductById(request.Id, cancellationToken);

        if (product is null)
        {
            return Error.NotFound("Product.NotFound", $"Product with id {request.Id} does not exist.");
        }

        return product;
    }
}
