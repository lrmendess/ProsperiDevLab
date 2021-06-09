using FluentValidation;
using ProsperiDevLab.Data;
using System.Linq;

namespace ProsperiDevLab.Models.Validations
{
    public class PriceValidation : AbstractValidator<Price>
    {
        public PriceValidation(ApplicationDbContext context)
        {
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0)
                .NotEmpty();

            RuleFor(x => x.CurrencyId)
                .NotEmpty()
                .Must(cid => context.Currencies.Any(c => c.Id == cid))
                .WithMessage("Currency not found.");

            RuleFor(x => x.Currency)
                .SetValidator(new CurrencyValidation(context))
                .When(c => c.Currency != null);
        }
    }
}
