using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Validations
{
    public class ServiceOrderValidation : AbstractValidator<ServiceOrder>
    {
        public ServiceOrderValidation()
        {
            RuleFor(x => x.Number)
                .NotEmpty();

            RuleFor(x => x.ExecutionDate)
                .NotEmpty()
                .LessThanOrEqualTo(DateTime.Now);

            RuleFor(x => x.PriceId)
                .NotEmpty();

            RuleFor(x => x.Price)
                .SetValidator(new PriceValidation())
                .When(x => x.Price != null);

            RuleFor(x => x.EmployeeId)
                .NotEmpty();

            RuleFor(x => x.Employee)
                .SetValidator(new EmployeeValidation())
                .When(x => x.Employee != null);

            RuleFor(x => x.CustomerId)
                .NotEmpty();

            RuleFor(x => x.Customer)
                .SetValidator(new CustomerValidation())
                .When(x => x.Customer != null);
        }
    }
}
