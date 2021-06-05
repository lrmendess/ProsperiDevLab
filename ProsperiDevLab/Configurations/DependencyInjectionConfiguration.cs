using Microsoft.Extensions.DependencyInjection;
using ProsperiDevLab.Data;
using ProsperiDevLab.Models.Validations;
using ProsperiDevLab.Repositories;
using ProsperiDevLab.Repositories.Interfaces;
using ProsperiDevLab.Services;
using ProsperiDevLab.Services.Interfaces;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<INotificator, Notificator>();
            services.AddScoped(typeof(ICrudService<,,>), typeof(CrudService<,,>));

            services.AddScoped<IServiceOrderService, ServiceOrderService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IServiceOrderRepository, ServiceOrderRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ServiceOrderValidation>();
            services.AddScoped<PriceValidation>();
            services.AddScoped<CurrencyValidation>();
            services.AddScoped<CustomerValidation>();
            services.AddScoped<EmployeeValidation>();
            
            return services;
        }
    }
}
