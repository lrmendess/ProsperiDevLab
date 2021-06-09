using FluentValidation;
using ProsperiDevLab.Data;
using System.Linq;

namespace ProsperiDevLab.Models.Validations
{
    public class CurrencyValidation : AbstractValidator<Currency>
    {
        public CurrencyValidation(ApplicationDbContext context)
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(3, 3);

            RuleFor(x => x.Code)
                .Must((x, code) => !context.Currencies.Any(c => c.Code == code && c.Id != x.Id))
                .WithMessage("Currency code already exists.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.Symbol)
                .NotEmpty()
                .MaximumLength(15);
        }
    }
}
