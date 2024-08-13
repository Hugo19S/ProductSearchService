using ProductSearchService.Domain;

namespace ProductSearchService.Application;

public interface IPendingNotificationRepository
{
    Task AddNotification(string message, string avatar, string username, CancellationToken ct);
    Task<List<PendingNotification>> GetNotifications(CancellationToken ct);
    Task DeleteNotification(PendingNotification notification, CancellationToken ct);
}
