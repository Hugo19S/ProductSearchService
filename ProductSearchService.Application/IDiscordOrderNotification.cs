using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSearchService.Application
{
    public interface IDiscordOrderNotification
    {
        Task DispatchNotification(string avatar, string username, string message, CancellationToken cancellationToken);
    }
}
