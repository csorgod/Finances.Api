using Finances.Core.Application.Interfaces;
using Finances.Core.Application.Notification.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Finances.Core.Application
{
    public class EntityCreated : INotification
    {
        public Guid Id { get; set; }

        public class EntityCreatedHandler<T> : INotificationHandler<T> where T : INotification
        {
            private readonly INotificationService _notification;

            public EntityCreatedHandler(INotificationService notification)
            {
                _notification = notification;
            }

            public async Task Handle(T notification, CancellationToken cancellationToken)
            {
                await _notification.SendAsync(new Message());
            }
        }
    }
}
