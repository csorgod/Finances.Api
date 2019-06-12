using FluentValidation;
using System;

namespace Finances.Core.Application.JwtManager.Commands.CancelToken
{
    public class CancelTokenValidator : AbstractValidator<CancelToken>
    {
        public CancelTokenValidator()
        {
            RuleFor(x => x.Token).NotEqual(Guid.Empty).NotEmpty().NotNull().WithErrorCode("O token não pode ser nulo.");
        }
    }
}
