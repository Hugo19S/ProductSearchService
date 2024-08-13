using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.Products.Queries.GetProduct;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.Products.Commands.UpdateProducts
{
    public record UpdateProductCommand(Guid ProductId, string ProductName, string Barcode, string? Image) : IRequest<ErrorOr<Product>>;

    public class UpdateProductCommandhandler(IProductRepository repository, IMediator _mediator, IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, ErrorOr<Product>>
    {
        public async Task<ErrorOr<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productExist = await repository.GetProductById(request.ProductId, cancellationToken);

            if (productExist == null) return Error.NotFound("Product.NotFound", $"Product with id {request.ProductId} does not exist.");

            if (request.ProductName != null) { productExist.Name = request.ProductName; }
            if (request.Barcode != null) { productExist.Barcode = request.Barcode; }
            if (request.Image != null) { productExist.Image = request.Image; }

            await repository.UpdateProduct(productExist, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new OrderNotification(
                 "https://i.imgur.com/Jq9Bimz.png",
                 "Product", $"The product with id {productExist.Id} has been updated!"
             ), cancellationToken);

            return productExist;
        }
    }
}
