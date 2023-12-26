using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;

namespace Todo.Domain.Validators.Commands
{
    public class ChangeToCompletedTaskCommandValidator : AbstractValidator<ChangeToCompletedTaskCommand>
    {
        public ChangeToCompletedTaskCommandValidator()
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
