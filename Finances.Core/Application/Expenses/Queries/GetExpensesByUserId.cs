using Finances.Common.Data;
using MediatR;
using System;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserId : IRequest<JsonDefaultResponse>
    {
        public Guid UserId { get; set; }
    }
}
