using FluentValidation;
using FluentValidation.Results;
using ProsperiDevLab.Services.Notificator;

namespace ProsperiDevLab.Services.Utils
{
    public class BaseService
    {
        private readonly INotificator _notificator;

        public BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        public virtual void Notify(NotificationType type, string property = "", string message = "")
        {
            _notificator.Handle(new Notification(type, property, message));
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
