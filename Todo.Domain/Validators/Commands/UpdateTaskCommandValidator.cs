

using FluentValidation;
using Todo.Domain.Commands;

namespace Todo.Domain.Validators.Commands
{
    public class UpdateTaskCommandValidator: AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor( command => command.Id )
                  .NotEmpty().WithMessage( "O Id não pode ser vazio." );

            RuleFor( command => command.Title )
                 .MaximumLength( 50 ).WithMessage( "O título não pode ter mais de 50 caracteres." );

            RuleFor( command => command.User )
                .NotEmpty().WithMessage( "O usuário não pode ser vazio." )
                .MaximumLength( 30 ).WithMessage( "O usuário não pode ter mais de 30 caracteres." );

            RuleFor( command => command.Description )
               .MaximumLength( 200 ).WithMessage( "A descrição não pode ter mais de 200 caracteres." );

        }
    }
}
