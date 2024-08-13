using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.Products.Commands.CreateProducts;

public record CreateProductCommand(string ProductName, string Barcode, string? Image) : IRequest<ErrorOr<Product>>;

public class CreateProductCommandHandler(
    IProductRepository repository,
    IUnitOfWork unitOfWork,
    IMediator _mediator) : IRequestHandler<CreateProductCommand, ErrorOr<Product>>
{
    public async Task<ErrorOr<Product>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var createdProduct = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.ProductName,
            Barcode = request.Barcode,
            Image = request.Image
        };

        var productAdded = await repository.AddProduct(createdProduct, cancellationToken);

        if (productAdded.IsError)
        {
            return productAdded.Errors;
        }

        await unitOfWork.SaveChangesAsync(cancellationToken);

        await _mediator.Publish(new OrderNotification(
            "https://i.imgur.com/Jq9Bimz.png",
            "Product", 
            $"a new product has been created with id {createdProduct.Id}!"),
            cancellationToken);


        return createdProduct;
    }
}
