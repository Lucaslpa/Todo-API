using FluentValidation;
using Todo.Domain.Commands.Contracts;


namespace Todo.Domain.Commands
{
    public class ChangeToUncompletTaskCommand( Guid taskId , string user, AbstractValidator<ChangeToUncompletTaskCommand> validator ) : Command<ChangeToUncompletTaskCommand>(validator), ICommand
    {
        public Guid Id { get; set; } = taskId;
        public string User { get; set; } = user;
      
    }
}
