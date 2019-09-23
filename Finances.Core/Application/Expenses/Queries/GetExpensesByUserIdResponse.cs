using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Finances.Core.Application;
using Finances.Core.Domain.Entities;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdResponse : BaseResponse
    {
        public IEnumerable<ExpensesByUserIdModel> Expenses { get; set; }
    }
}
