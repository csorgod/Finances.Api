using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using Finances.Core.Application.Notification.Notifier;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Favoreds.Commands.CreateFavored
{
    public class FavoredCreated : BaseNotifier, INotification
    {
        public class FavoredCreatedHandler : INotificationHandler<FavoredCreated>
        {
            private readonly INotificationService _notification;

            public FavoredCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(FavoredCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }

    }
}
