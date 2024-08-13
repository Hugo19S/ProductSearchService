using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;

namespace ProductSearchService.Application.Products.Commands.DeleteProducts
{
    public record DeleteProductCommand(Guid ProductId) : IRequest<ErrorOr<Guid>>;

    public class DeleteProductCommandHandler(IProductRepository repository, IMediator _mediator, IUnitOfWork unitOfWork) : IRequestHandler<DeleteProductCommand, ErrorOr<Guid>>
    {
        public async Task<ErrorOr<Guid>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repository.GetProductById(request.ProductId, cancellationToken);

            if (product == null) return Error.NotFound("Product.NotFound", $"Product with id {request.ProductId} does not exist.");

            await repository.DeleteProduct(product, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new OrderNotification(
                "https://i.imgur.com/Jq9Bimz.png",
                "Product", $"Product with id {product.Id} was deleted!"
            ), cancellationToken);

            

            return product.Id;
        }
    }
}
