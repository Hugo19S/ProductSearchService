using MediatR;
using System.Net.Http.Json;

namespace ProductSearchService.Application.SendMessages;

public record OrderNotification(string Avatar, string Username, string Message) : INotification;

public class OrderNotificationHandler(IDiscordOrderNotification dispatcher) : INotificationHandler<OrderNotification>
{
    public async Task Handle(OrderNotification notification, CancellationToken cancellationToken)
    {
        await dispatcher.DispatchNotification(notification.Avatar, notification.Username, notification.Message, cancellationToken);
    }
}
