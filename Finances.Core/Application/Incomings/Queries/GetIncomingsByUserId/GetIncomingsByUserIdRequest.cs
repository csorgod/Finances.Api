using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class GetIncomingsByUserIdRequest : IRequest<GetIncomingsByUserIdResponse>
    {
        public Guid UserId { get; set; }
    }
}
