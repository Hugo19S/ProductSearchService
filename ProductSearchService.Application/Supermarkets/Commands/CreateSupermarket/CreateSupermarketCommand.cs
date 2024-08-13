using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Domain;

namespace ProductSearchService.Application.Supermarkets.Commands.CreateSupermarket
{
    public record CreateSupermarketCommand(string SupermarketName) : IRequest<ErrorOr<Supermarket>>;

    public class CreateSupermarketCommandHandler(
        ISupermarketRepository repository, 
        IPublisher publisher,
        IUnitOfWork unitOfWork) : IRequestHandler<CreateSupermarketCommand, ErrorOr<Supermarket>>
    {
        public async Task<ErrorOr<Supermarket>> Handle(CreateSupermarketCommand request, CancellationToken cancellationToken)
        {
            var newSupermarket = new Supermarket
            {
                Id = Guid.NewGuid(),
                Name = request.SupermarketName,
            };

            var createdSupermarket = await repository.AddSupermarket(newSupermarket, cancellationToken);

            if (createdSupermarket.IsError)
            {
                return createdSupermarket.Errors;
            }

            await unitOfWork.SaveChangesAsync(cancellationToken);

            await publisher.Publish(new OrderNotification(
              "https://i.imgur.com/dO4KuD5.png",
              "Supermarket",
              $"A new Supermarket has been newd with id {newSupermarket.Id}!"
              ), cancellationToken);

            return newSupermarket;
        }
    }
}
