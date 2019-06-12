using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using Finances.Core.Application.Notification.Notifier;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Authorization.Commands.CreateAccount
{
    public class AccountCreated : BaseNotifier, INotification
    {
        public class AccountCreatedHandler : INotificationHandler<AccountCreated>
        {
            private readonly INotificationService _notification;

            public AccountCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(AccountCreated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
