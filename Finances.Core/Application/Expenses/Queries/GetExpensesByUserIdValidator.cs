using FluentValidation;

namespace Finances.Core.Application.Expenses.Queries.GetExpensesByUserId
{
    public class GetExpensesByUserIdValidator : AbstractValidator<GetExpensesByUserIdRequest>
    {
        public GetExpensesByUserIdValidator() { }
    }
}
