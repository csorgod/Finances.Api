using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Finances.Core.Application.Authorization.Commands.CreateAccount
{
    class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Username).Length(5, 40).NotEmpty().WithMessage("O usuário precisa ter no mínimo 5 e no máximo 40 caracteres");
            RuleFor(x => x.Password).Length(8, 40).NotEmpty().WithMessage("A senha precisa ter no mínimo 8 e no máximo 40 caracteres");
            RuleFor(x => x.FirstName).Length(2, 20).NotEmpty().WithMessage("O nome precisa ter no mínimo 2 e no máximo 20 caracteres");
            RuleFor(x => x.LastName).Length(2, 50).NotEmpty().WithMessage("O sobrenome precisa ter no mínimo 2 e no máximo 50 caracteres");
            RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("Você precisa ter mais de 18 anos pra criar uma conta");
            RuleFor(x => x.TaxNumber).Length(14).Matches(@"^\d{3}.\d{3}.\d{3}-\d{2}$").NotEmpty().WithMessage("O CPF informado não é valido.");
            RuleFor(x => x.Gender).Must(BeMaleOrFemale).When(x => x.Gender != char.MinValue).WithMessage("O sexo informado não é válido");
            RuleFor(x => x.PhoneNumber).Length(10, 11).Must(DontHaveMask).WithMessage("O telefone informado não é válido");
            RuleFor(x => x.Email).Length(50).EmailAddress().WithMessage("O e-mail informado não é válido");
            RuleFor(x => x.ImagePath).Length(500).Must(BeAValidUrl).WithMessage("O e-mail informado não é válido");
        }

        private bool BeMaleOrFemale(char gender) => gender.ToLower() == 'm' || gender.ToLower() == 'f';

        private bool DontHaveMask(string phone)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (regexItem.IsMatch(phone))
                return false;
            return true;
        }

        private static bool BeAValidUrl(string arg)
        {
            Uri result;
            return Uri.TryCreate(arg, UriKind.Absolute, out result);
        }
    }
}
