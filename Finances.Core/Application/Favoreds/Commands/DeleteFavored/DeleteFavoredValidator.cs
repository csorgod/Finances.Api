using FluentValidation;
using System;

namespace Finances.Core.Application.Favoreds.Commands.DeleteFavored
{
    public class DeleteFavoredValidator : AbstractValidator<DeleteFavored>
    {
        public DeleteFavoredValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).NotEmpty().NotNull().WithErrorCode("O Id não pode ser nulo.");
        }

    }
}
