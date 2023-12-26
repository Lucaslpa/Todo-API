
using FluentValidation;
using Todo.Domain.Commands;

namespace Todo.Domain.Validators.Commands
{
    public class ChangeToUncompletTaskCommandValidator : AbstractValidator<ChangeToUncompletTaskCommand>
    {
        public ChangeToUncompletTaskCommandValidator()
        {  

            RuleFor( x => x.Id )
                .NotEmpty()
                .WithMessage( "Id da tarefa não pode ser vazio" );

            RuleFor( command => command.User )
                   .NotEmpty().WithMessage( "O usuário não pode ser vazio." )
                   .MaximumLength( 30 ).WithMessage( "O usuário não pode ter mais de 30 caracteres." );


        }

    }
}
