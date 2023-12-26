using FluentValidation;

namespace Todo.Domain.Commands
{
    public class CreateNewTaskCommandValidator : AbstractValidator<CreateNewTaskCommand>
    {
        public CreateNewTaskCommandValidator()
        {
            RuleFor( command => command.Title )
                .NotEmpty().WithMessage( "O título não pode ser vazio." )
                .MaximumLength( 50 ).WithMessage( "O título não pode ter mais de 50 caracteres." );

            RuleFor( command => command.User )
                .NotEmpty().WithMessage( "O usuário não pode ser vazio." )
                .MaximumLength( 30 ).WithMessage( "O usuário não pode ter mais de 30 caracteres." );

            RuleFor( command => command.Description )
                .NotEmpty().WithMessage( "A descrição não pode ser vazia." )
                .MaximumLength( 200 ).WithMessage( "A descrição não pode ter mais de 200 caracteres." );
           
        }

    }
}
