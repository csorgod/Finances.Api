using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using System.Threading.Tasks;

namespace Finances.Infrastructure.Infrastructure
{
    public class NotificationService : INotificationService
    {
        public Task SendAsync(Message message)
            => Task.CompletedTask;
    }
}
