using FluentValidation;
using FluentValidation.Results;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Services.Utils
{
    public class BaseService
    {
        protected readonly INotificator Notificator;

        public BaseService(INotificator notificator)
        {
            Notificator = notificator;
        }

        public virtual void Notify(NotificationType type, string property = "", string message = "")
        {
            Notificator.Handle(new Notification(type, property, message));
        }

        public virtual void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(NotificationType.ERROR, error.PropertyName, error.ErrorMessage);
            }
        }

        public virtual bool IsValid<TV, TE>(TV validation, TE entity, params string[] ruleSets)
            where TV : AbstractValidator<TE>
            where TE : class
        {
            if (entity == null)
            {
                Notify(NotificationType.ERROR, string.Empty, $"{typeof(TE).Name} not found.");
                return false;
            }

            var validator = validation.Validate(entity, options => options.IncludeRuleSets(ruleSets));

            if (validator.IsValid)
            {
                return true;
            }

            Notify(validator);
            return false;
        } 
    }
}
