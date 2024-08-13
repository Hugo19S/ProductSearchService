using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;

namespace ProductSearchService.Application.SupermarketProducts.Commands.DeleteSupermarketProduct;

public record DeleteSupermarketProductCommand(Guid SupermarketId, Guid ProductId) : IRequest<ErrorOr<Tuple<Guid, Guid>>>;

public class DeleteSupermarketProductCommandHandler(
    IProductRepository productRepository,
    ISupermarketRepository supermarketRepository,
    ISupermarketProductRepository supermarketProductRepository,
    IPublisher _publisher,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<DeleteSupermarketProductCommand, ErrorOr<Tuple<Guid, Guid>>>
{
    public async Task<ErrorOr<Tuple<Guid, Guid>>> Handle(DeleteSupermarketProductCommand request, CancellationToken cancellationToken)
    {
        var supermarketExist = await supermarketRepository.GetSupermarketById(request.SupermarketId, cancellationToken);
        var productExist = await productRepository.GetProductById(request.ProductId, cancellationToken);
        var supermarketProductExist = await supermarketProductRepository.GetSupermarketProductById(request.SupermarketId, request.ProductId, cancellationToken);

        if (supermarketExist == null) return Error.NotFound("Supermarket.NotFound", $"Supermarket with id {request.SupermarketId} does not exist.");
        else if (productExist == null) return Error.NotFound("Product.NotFound", $"Product with id {request.ProductId} does not exist.");
        else if (supermarketProductExist == null) return Error.NotFound("SupermarketProduct.NotFound",
                                                                        $"Product with id {request.ProductId} does not exist in the Supermarket with id {request.SupermarketId}.");

        await supermarketProductRepository.DeleteSupermarketProduct(supermarketProductExist, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        await _publisher.Publish(new OrderNotification(
          "https://i.imgur.com/jiD06Cp.png",
          "SupermarketProduct", 
          $"The product with the id {supermarketProductExist.ProductId} has been deleted from Supermarket with the id {supermarketProductExist.SupermarketId}!"
        ), cancellationToken);

        return Tuple.Create(request.SupermarketId, request.ProductId);
    }
}
