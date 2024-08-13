using ErrorOr;
using MediatR;
using ProductSearchService.Application.Common;
using ProductSearchService.Application.SendMessages;
using ProductSearchService.Application.Supermarkets.Queries.GetSupermarket;
using ProductSearchService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application.Supermarkets.Commands.DeleteSupermarket
{
    public record DeleteSupermarketCommand(Guid SupermarketId) : IRequest<ErrorOr<Guid>>;

    public class DeleteSupermarketCommandHandler(
        ISupermarketRepository repository, 
        IPublisher publisher,
        IUnitOfWork unitOfWork) : IRequestHandler<DeleteSupermarketCommand, ErrorOr<Guid>>
    {
        public async Task<ErrorOr<Guid>> Handle(DeleteSupermarketCommand request, CancellationToken cancellationToken)
        {
            var supermarketToDeleted = await repository.GetSupermarketById(request.SupermarketId, cancellationToken);

            if (supermarketToDeleted == null) return Error.NotFound("Supermarket.NotFound", $"Supermarket with id {request.supermarketId} does not exist."); ;

            await repository.DeleteSupermarket(supermarketToDeleted, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);

            await publisher.Publish(new OrderNotification(
               "https://i.imgur.com/dO4KuD5.png",
               "Product", $"The supermarket with id {request.SupermarketId} has been deleted!"
            ), cancellationToken);

            return request.SupermarketId;
        }
}
}
