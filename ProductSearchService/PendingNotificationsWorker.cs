
using ProductSearchService.Application;
using ProductSearchService.Infrastructure;

namespace ProductSearchService.WebApi;

public class PendingNotificationsWorker(IServiceScopeFactory scopeFactory) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        PeriodicTimer timer = new(TimeSpan.FromMinutes(10));

        
        while (!stoppingToken.IsCancellationRequested)
        {
            using IServiceScope scope = scopeFactory.CreateScope();

            var repository = scope.ServiceProvider.GetRequiredService<IPendingNotificationRepository>();
            

            var pendingNotifications = await repository.GetNotifications(stoppingToken);

            if(pendingNotifications.Count > 0)
            {
                var dispatcher = scope.ServiceProvider.GetRequiredService<IDiscordOrderNotification>();
                foreach (var notification in pendingNotifications)
                {
                    await repository.DeleteNotification(notification, stoppingToken);
                    await dispatcher.DispatchNotification(notification.Avatar, notification.Username, notification.Message, stoppingToken);
                }
            }

            await timer.WaitForNextTickAsync(stoppingToken);
        }
    }
}