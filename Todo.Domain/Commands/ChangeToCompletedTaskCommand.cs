using FluentValidation;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class ChangeToCompletedTaskCommand( Guid taskId , string user, AbstractValidator<ChangeToCompletedTaskCommand> validator ) : Command<ChangeToCompletedTaskCommand>(validator), ICommand
    {
        public Guid Id { get; set; } = taskId;
        public string User { get; set; } = user;
  
    }
}
