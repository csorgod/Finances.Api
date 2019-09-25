using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Finances.Core.Application;
using Finances.Core.Domain.Entities;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class GetIncomingsByUserIdResponse : BaseResponse
    {
        public IEnumerable<IncomingsByUserIdModel> Incomings { get; set; }
    }
}
