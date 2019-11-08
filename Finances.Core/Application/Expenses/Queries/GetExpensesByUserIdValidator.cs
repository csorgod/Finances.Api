using FluentValidation;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdValidator : AbstractValidator<ExpensesByUserId>
    {
        public GetExpensesByUserIdValidator() { }
    }
}
