using FluentValidation;
using ProsperiDevLab.Data;
using System.Linq;

namespace ProsperiDevLab.Models.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation(ApplicationDbContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.CNPJ)
                .NotEmpty()
                .IsValidCNPJ()
                .WithMessage("CNPJ is invalid.");
            
            RuleFor(x => x.CNPJ)
                .Must((x, cnpj) => !context.Customers.Any(c => c.CNPJ == cnpj && c.Id != x.Id))
                .WithMessage("Customer already exists.");
        }
    }
}
