using FluentValidation;
using ProsperiDevLab.Data;
using System;
using System.Linq;

namespace ProsperiDevLab.Models.Validations
{
    public class ServiceOrderValidation : AbstractValidator<ServiceOrder>
    {
        public ServiceOrderValidation(ApplicationDbContext context)
        {
            RuleFor(x => x.Number)
                .NotEmpty()
                .MaximumLength(63);

            RuleFor(x => x.Number)
                .Must((x, number) => !context.ServiceOrders.Any(s => s.Number == number && s.Id != x.Id))
                .WithMessage("Service order number already exists.");

            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(255);

            RuleFor(x => x.ExecutionDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.Price)
                .SetValidator(new PriceValidation(context))
                .When(x => x.Price != null);

            RuleFor(x => x.Employee)
                .SetValidator(new EmployeeValidation(context))
                .When(x => x.Employee != null);

            RuleFor(x => x.Customer)
                .SetValidator(new CustomerValidation(context))
                .When(x => x.Customer != null);

            RuleSet("update", () =>
            {
                RuleFor(x => x.PriceId)
                    .NotEmpty();
            });
        }
    }
}
