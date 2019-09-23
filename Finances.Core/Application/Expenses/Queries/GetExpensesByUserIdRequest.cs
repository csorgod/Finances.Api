using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdRequest : IRequest<GetExpensesByUserIdResponse>
    {
        public Guid UserId { get; set; }
    }
}
