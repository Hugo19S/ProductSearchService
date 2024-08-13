using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.SupermarketProducts.Commands.CreateSupermarketProduct;

public record CreateSupermarketProductCommand(Guid SupermarketId, Guid ProductId, int Quantity, decimal Price, string? Description) : IRequest<ErrorOr<SupermarketProduct>>;

public class CreateSupermarketProductCommandHandler(
    IProductRepository productRepository,
    ISupermarketRepository supermarketRepository,
    ISupermarketProductRepository supermarketProductRepository,
    IPublisher _publisher,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<CreateSupermarketProductCommand, ErrorOr<SupermarketProduct>>
{
    public async Task<ErrorOr<SupermarketProduct>> Handle(CreateSupermarketProductCommand request, CancellationToken cancellationToken)
    {
        var supermarketExist = await supermarketRepository.GetSupermarketById(request.SupermarketId, cancellationToken);
        var productExist = await productRepository.GetProductById(request.ProductId, cancellationToken);

        if (supermarketExist == null) return Error.NotFound("Supermarket.NotFound", $"Supermarket with id {request.SupermarketId} does not exist.");
        else if (productExist == null) return Error.NotFound("Product.NotFound", $"Product with id {request.ProductId} does not exist.");

        var supermarketProduct = new SupermarketProduct
        {
            SupermarketId = request.SupermarketId,
            ProductId = request.ProductId,
            ProductQuantity = request.Quantity,
            Price = request.Price,
            Description = request.Description,
            CreatedOn = DateTime.UtcNow
        };

        await supermarketProductRepository.AddSupermarketProduct(supermarketProduct, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await _publisher.Publish(new OrderNotification(
          "https://i.imgur.com/jiD06Cp.png",
          "SupermarketProduct", $"The product with id {supermarketProduct.ProductId} has been added to Supermarket with id {supermarketProduct.SupermarketId}!"
        ), cancellationToken);

        return supermarketProduct;
    }
}
