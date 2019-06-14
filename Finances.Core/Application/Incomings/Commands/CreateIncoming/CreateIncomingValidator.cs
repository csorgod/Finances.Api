using FluentValidation;
using System;

namespace Finances.Core.Application.Incomings.Commands.CreateIncoming
{
    public class CreateIncomingValidator : AbstractValidator<CreateIncoming>
    {
        public CreateIncomingValidator()
        {
            RuleFor(x => x.IncomeType).NotEmpty().WithMessage("O tipo de receita informado não é valido.");
            RuleFor(x => x.Name).Length(30).NotEmpty().WithMessage("O Nome informado não pode ter mais do que 30 Caracteres.");
            RuleFor(x => x.Description).Length(1000).WithMessage("A descrição não pode conter mais do que 1000 Caracteres.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("O valor informado não pode ser 0.00.");
            RuleFor(x => x.ReceiveAt);
            RuleFor(x => x.Recurrent);
        }

        private bool BeAValidGuid(Guid value)
        {
            Guid newGuid;

            if (Guid.TryParse(value.ToString(), out newGuid))
                return true;

            return false;
        }
    }
}
