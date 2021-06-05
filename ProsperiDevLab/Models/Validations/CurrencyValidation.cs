using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Validations
{
    public class CurrencyValidation : AbstractValidator<Currency>
    {
        public CurrencyValidation()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .Length(3, 3);

            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Symbol)
                .NotEmpty();
        }
    }
}
