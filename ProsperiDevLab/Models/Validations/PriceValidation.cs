using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Validations
{
    public class PriceValidation : AbstractValidator<Price>
    {
        public PriceValidation()
        {
            RuleFor(x => x.Value)
                .GreaterThanOrEqualTo(0)
                .NotEmpty();

            RuleFor(x => x.CurrencyId)
                .NotEmpty();

            RuleFor(x => x.Currency)
                .SetValidator(new CurrencyValidation())
                .When(c => c.Currency != null);
        }
    }
}
