using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.SupermarketProducts.Commands.UpdateSupermarketProduct;

public record UpdateSupermarketProductCommand(Guid SupermarketId, Guid ProductId, decimal Price, int ProductQuantity, string? Description) : IRequest<ErrorOr<SupermarketProduct>>;

public class UpdateSupermarketProductCommandHandler(
    IProductRepository productRepository,
    ISupermarketRepository supermarketRepository,
    ISupermarketProductRepository supermarketProductRepository,
    IPublisher _publisher,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateSupermarketProductCommand, ErrorOr<SupermarketProduct>>
{
    public async Task<ErrorOr<SupermarketProduct>> Handle(
        UpdateSupermarketProductCommand request, CancellationToken cancellationToken)
    {
        var supermarketExist = await supermarketRepository
            .GetSupermarketById(request.SupermarketId, cancellationToken);

        var productExist = await productRepository
            .GetProductById(request.ProductId, cancellationToken);

        var supermarketProductExist = await supermarketProductRepository
            .GetSupermarketProductById(request.SupermarketId, request.ProductId, cancellationToken);

        if (supermarketExist == null) return Error.NotFound("Supermarket.NotFound", $"Supermarket with id {request.SupermarketId} does not exist.");
        else if (productExist == null) return Error.NotFound("Product.NotFound", $"Product with id {request.ProductId} does not exist.");
        else if (supermarketProductExist == null) return Error.NotFound("SupermarketProduct.NotFound",
                                                                        $"Product with id {request.ProductId} does not exist in the Supermarket with id {request.SupermarketId}.");

        if(request.Price != 0) supermarketProductExist.Price = request.Price;
        if (request.Description != null)  supermarketProductExist.Description = request.Description;
        if (request.ProductQuantity != 0)  supermarketProductExist.ProductQuantity = request.ProductQuantity;
        supermarketProductExist.UpdatedOn = DateTime.UtcNow;

        await supermarketProductRepository.UpdateSupermarketProduct(supermarketProductExist, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await _publisher.Publish(new OrderNotification(
             "https://i.imgur.com/jiD06Cp.png",
             "SupermarketProduct",
             $"The product with the id {supermarketProductExist.ProductId} has been updated in Supermarket with the id {supermarketProductExist.SupermarketId}!"
         ), cancellationToken);

        return supermarketProductExist;
    }
}
