using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class IncomingsByUserId : IRequest<JsonDefaultResponse>
    {
        public Guid UserId { get; set; }
    }
}
