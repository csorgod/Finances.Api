using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Finances.Core.Application.Authorization.Commands.CreateAccount
{
    public class CreateAccountValidator : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Username).Length(5, 40).WithMessage("O usuário precisa ter no mínimo 5 e no máximo 40 caracteres");
            RuleFor(x => x.Password).Length(8, 40).WithMessage("A senha precisa ter no mínimo 8 e no máximo 40 caracteres");
            RuleFor(x => x.FirstName).Length(2, 20).WithMessage("O nome precisa ter no mínimo 2 e no máximo 20 caracteres");
            RuleFor(x => x.LastName).Length(2, 50).WithMessage("O sobrenome precisa ter no mínimo 2 e no máximo 50 caracteres");
            RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("Você precisa ter mais de 18 anos pra criar uma conta");
            RuleFor(x => x.TaxNumber).Must(BeAValidCPF).WithMessage("O CPF informado não é valido.");
            RuleFor(x => x.Gender).Must(BeMaleOrFemale).When(x => x.Gender != char.MinValue).WithMessage("O sexo informado não é válido");
            RuleFor(x => x.PhoneNumber).Length(10, 11).Must(BeWithoutMask).WithMessage("O telefone informado não é válido");
            RuleFor(x => x.Email).Length(4, 50).EmailAddress().WithMessage("O e-mail informado não é válido");
            //RuleFor(x => x.ImagePath).Length(500).Must(BeAValidUrl).WithMessage("O e-mail informado não é válido");
        }

        private bool BeMaleOrFemale(char gender) => Char.ToLower(gender) == 'm' || Char.ToLower(gender) == 'f';
        private bool BeWithoutMask(string phone) => phone.Length == Regex.Replace(phone, "[^0-9]", "").Length;
        private bool BeAValidUrl(string arg) => Uri.TryCreate(arg, UriKind.Absolute, out Uri result);
        private bool BeAValidCPF(string cpf) => true;
    }
}
