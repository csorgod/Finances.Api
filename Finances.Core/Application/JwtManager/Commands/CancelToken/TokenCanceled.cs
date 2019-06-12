using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using Finances.Core.Application.Notification.Notifier;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.JwtManager.Commands.CancelToken
{
    public class TokenCanceled : BaseNotifier, INotification
    {
        public class TokenCanceledHandler : INotificationHandler<TokenCanceled>
        {
            private readonly INotificationService _notification;

            public TokenCanceledHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(TokenCanceled notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
