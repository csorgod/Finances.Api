using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using Finances.Core.Application.Notification.Notifier;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application.Authorization.Commands.SignIn
{
    public class UserAuthenticated : BaseNotifier, INotification
    {
        public class UserAuthenticatedHandler : INotificationHandler<UserAuthenticated>
        {
            private readonly INotificationService _notification;

            public UserAuthenticatedHandler(INotificationService notification)
            {
                _notification = notification;
            }
            public async Task Handle(UserAuthenticated notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
