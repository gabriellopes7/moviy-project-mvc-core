

using FluentValidation;
using FluentValidation.Results;
using Moviy.Business.Interfaces;
using Moviy.Business.Models;
using Moviy.Business.Notifications;

namespace Moviy.Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificator _notificator;

        protected BaseService(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }
        protected void Notificar(string message)
        {
            _notificator.Handle(new Notification(message));
        }

        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validation.Validate(entity);
            if (validator.IsValid)
                return true;
            Notificar(validator);
            return false;
        }
    }
}
