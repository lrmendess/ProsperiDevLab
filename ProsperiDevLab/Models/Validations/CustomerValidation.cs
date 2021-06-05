using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .IsValidCNPJ();
        }
    }
}
