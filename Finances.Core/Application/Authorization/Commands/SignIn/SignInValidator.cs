using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Authorization.Commands.SignIn
{
    public class SignInValidator : AbstractValidator<SignIn>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Username)
                .MaximumLength(40).WithMessage("O usuário não pode ter mais de 40 caracteres")
                .NotEmpty().WithMessage("O usuário não pode estar vazio");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha não pode estar vazia");
        }
    }
}
