using FluentValidation;
using ProsperiDevLab.Data;
using System.Linq;

namespace ProsperiDevLab.Models.Validations
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation(ApplicationDbContext context)
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.CPF)
                .NotEmpty()
                .IsValidCPF();

            RuleFor(x => x.CPF)
                .Must((x, cpf) => !context.Employees.Any(e => e.CPF == cpf && e.Id != x.Id))
                .WithMessage("Employee already exists.");
        }
    }
}
