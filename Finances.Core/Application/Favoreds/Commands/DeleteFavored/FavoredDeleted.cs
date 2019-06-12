using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using Finances.Core.Application.Notification.Notifier;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Favoreds.Commands.DeleteFavored
{
    public class FavoredDeleted : BaseNotifier, INotification
    {
        public class FavoredDeletedHandler : INotificationHandler<FavoredDeleted>
        {
            private readonly INotificationService _notification;

            public FavoredDeletedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(FavoredDeleted notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
