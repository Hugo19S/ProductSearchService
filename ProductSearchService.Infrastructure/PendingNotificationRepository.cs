using Microsoft.EntityFrameworkCore;
using ProductSearchService.Application;
using ProductSearchService.Domain;

namespace ProductSearchService.Infrastructure
{
    public class PendingNotificationRepository (AppDbContext dbContext) : IPendingNotificationRepository
    {
        public async Task AddNotification(string message, string avatar, string username, CancellationToken ct)
        {
            var notifications = new PendingNotification
            {
                Id = Guid.NewGuid(),
                Message = message,
                Avatar = avatar,
                Username = username,
            };
            await dbContext.PendingNotification.AddAsync(notifications, ct);
            await dbContext.SaveChangesAsync(ct);
        }

        public async Task<List<PendingNotification>> GetNotifications(CancellationToken ct)
        {
            return await dbContext.PendingNotification.ToListAsync(ct);
        }

        public async Task DeleteNotification(PendingNotification notification, CancellationToken ct)
        {
            dbContext.PendingNotification.Remove(notification);
            await dbContext.SaveChangesAsync(ct);
        }
    }
}
