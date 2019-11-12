using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using Finances.Core.Application.Notification.Notifier;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Incomings.Commands.CreateIncoming
{
    public class IncomingCreated : BaseNotifier, INotification
    {
        public class IncomingCreatedHandler : INotificationHandler<IncomingCreated>
        {
            private readonly INotificationService _notification;

            public IncomingCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(IncomingCreated notification, CancellationToken cancellationToken)
                => await _notification.SendAsync(new Message());
        }
    }
}
