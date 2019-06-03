using Finances.Core.Application.Notification.Models;
using System.Threading.Tasks;

namespace Finances.Core.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(Message message);
    }
}
