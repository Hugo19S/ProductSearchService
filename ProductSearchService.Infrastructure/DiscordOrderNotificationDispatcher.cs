using MediatR;
using Microsoft.Extensions.Logging;
using ProductSearchService.Application;
using System.Net.Http;
using System.Net.Http.Json;

namespace ProductSearchService.Infrastructure;

public class DiscordOrderNotificationDispatcher(HttpClient httpClient, IPendingNotificationRepository notificationRepository) : IDiscordOrderNotification
{
    public async Task DispatchNotification(string avatar, string username, string message, CancellationToken cancellationToken)
    {
        try
        {
            var response = await httpClient.PostAsJsonAsync("", new
            {
                content = message,
                avatar_url = avatar,
                username

            }, cancellationToken);
        }
        catch (Exception)
        {
            await notificationRepository.AddNotification(message, avatar, username, cancellationToken);
            //logger.LogError("Failed to send notification {ex}", ex);
            // Log or handle the exception as needed
            //throw new ApplicationException("Failed to send notification", ex);
            // ... save to db
        }
    }
}
