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
            RuleFor(x => x.Username).MaximumLength(40).Empty().WithMessage("O Usuário informado está incorreto");
            RuleFor(x => x.Password).Empty().WithMessage("A senha informada está incorreto");
        }
    }
}
