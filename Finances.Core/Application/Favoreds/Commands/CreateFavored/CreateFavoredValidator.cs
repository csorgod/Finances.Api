using FluentValidation;

namespace Finances.Core.Application.Favoreds.Commands.CreateFavored
{
    public class CreateFavoredValidator : AbstractValidator<CreateFavored>
    {
        public CreateFavoredValidator()
        {
            RuleFor(x => x.Name).Length(50).NotEmpty();
            RuleFor(x => x.TaxNumber).Length(14).Matches(@"^\d{3}.\d{3}.\d{3}-\d{2}$").NotEmpty();
        }
    }
}
