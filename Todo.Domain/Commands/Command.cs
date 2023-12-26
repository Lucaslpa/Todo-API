
using FluentValidation;
using Todo.Domain.Notifications;

namespace Todo.Domain.Commands
{
    public abstract class Command<T>( AbstractValidator<T> validator ) : Notifiable where T : Command<T>
    {
        private readonly AbstractValidator<T> _validator = validator;

        public bool Validate()
        {
            var validationResult = _validator.Validate( (T)this );

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    AddNotification( new Notification( error.PropertyName , error.ErrorMessage ) );
                }
            }

            return validationResult.IsValid;

        }
    }
}
