using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductSearchService.Application;
using Microsoft.EntityFrameworkCore;
using ProductSearchService.Application.Common;

namespace ProductSearchService.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfigurationManager configuration)
    {
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISupermarketRepository, SupermarketRepository>();
        services.AddScoped<ISupermarketProductRepository, SupermarketProductRepository>();
        services.AddScoped<IPendingNotificationRepository, PendingNotificationRepository>();
        services.AddScoped<IDiscordOrderNotification, DiscordOrderNotificationDispatcher>(); /********************/


        services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration.GetConnectionString("SupermarketDatabase"));
        });

        string discordWebhookUrl = configuration["Webhooks:Discord"]!;

        services.AddHttpClient<IDiscordOrderNotification, DiscordOrderNotificationDispatcher>(client =>
        {
            client.BaseAddress = new Uri(discordWebhookUrl);
        });

        services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<AppDbContext>());

        return services;
    }
}