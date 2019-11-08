using Finances.Core.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class ExpensesByUserIdModel
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public bool Recurrent { get; set; }

        public static Expression<Func<Expense, ExpensesByUserIdModel>> Projection
        {
            get
            {
                return Expense => new ExpensesByUserIdModel
                {
                    Id = Expense.Id,
                    PersonId = Expense.PersonId,
                    Name = Expense.Name,
                    Description = Expense.Description,
                    Value = Expense.Value,
                    Recurrent = Expense.Recurrent
                };
            }
        }

        public static ExpensesByUserIdModel Create(Expense Expense)
            => Projection.Compile().Invoke(Expense);
    }
}
