using FluentValidation;

namespace Finances.Core.Application.Incomings.Queries.GetIncomingsByUserId
{
    public class GetIncomingsByUserIdValidator : AbstractValidator<IncomingsByUserId>
    {
        public GetIncomingsByUserIdValidator() { }
    }
}
