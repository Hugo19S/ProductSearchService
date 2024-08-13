using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.Supermarkets.Commands.UpdateSupermarket
{
    public record UpdateSupermarketCommand(Guid SupermarketId, string SupermarketName) : IRequest<ErrorOr<Supermarket>>;

    public class UpdateSupermarketCommandHandler(
        ISupermarketRepository repository, 
        IPublisher publisher,
        IUnitOfWork unitOfWork) : IRequestHandler<UpdateSupermarketCommand, ErrorOr<Supermarket>>
    {
        public async Task<ErrorOr<Supermarket>> Handle(UpdateSupermarketCommand request, CancellationToken cancellationToken)
        {
            var supermarketToUpdate = await repository.GetSupermarketById(request.SupermarketId, cancellationToken);

            if (supermarketToUpdate == null) return Error.NotFound("Supermarket.NotFound", $"Supermarket with id {request.SupermarketId} does not exist.");

            supermarketToUpdate.Name = request.SupermarketName;

            await repository.UpdateSupermarket(supermarketToUpdate, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await publisher.Publish(new OrderNotification(
                "https://i.imgur.com/dO4KuD5.png",
                "Supermarket",
                $"The supermarket with id {request.SupermarketId} has been updated!"
            ), cancellationToken);

            return supermarketToUpdate;
        }
}
}
