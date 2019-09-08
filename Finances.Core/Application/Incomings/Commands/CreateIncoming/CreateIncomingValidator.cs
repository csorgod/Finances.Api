using FluentValidation;
using System;

namespace Finances.Core.Application.Incomings.Commands.CreateIncoming
{
    public class CreateIncomingValidator : AbstractValidator<CreateIncoming>
    {
        public CreateIncomingValidator()
        {
            RuleFor(x => x.IncomeType).NotEmpty().WithMessage("O tipo de receita informado não é valido.");
            RuleFor(x => x.Name).Length(1, 30).WithMessage("O Nome deve ter entre 1 e 30 caracteres.");
            RuleFor(x => x.Description).Length(1, 1000).WithMessage("A descrição deve ter entre 1 e 1000 caracteres.");
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
