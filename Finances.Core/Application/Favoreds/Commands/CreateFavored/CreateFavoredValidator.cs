using FluentValidation;

namespace Finances.Core.Application.Favoreds.Commands.CreateFavored
{
    public class CreateFavoredValidator : AbstractValidator<CreateFavored>
    {
        public CreateFavoredValidator()
        {
            RuleFor(x => x.Name).Length(1, 50).WithMessage("O Nome informado não pode ter mais do que 50 Caracteres.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("O Nome informado não foi preenchido.");
            RuleFor(x => x.BelongToUserId).NotEmpty().WithMessage("O CPF informado não é valido.");
            RuleFor(x => x.TaxNumber).Length(11).NotEmpty().WithMessage("O CPF informado não é valido.");
        }
    }
}
