using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProsperiDevLab.Models.Validations
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.CPF)
                .NotEmpty()
                .IsValidCPF();
        }
    }
}
