using Finances.Common.Data;
using MediatR;
using System;
using System.Collections.Generic;

namespace Finances.Core.Application.Users.Queries.GetProfileByUserId
{
    public class ProfileByUserId : IRequest<JsonDefaultResponse>
    {
        public Guid UserId { get; set; }
    }
}
