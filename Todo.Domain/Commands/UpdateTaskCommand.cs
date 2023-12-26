
using FluentValidation;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Notifications;

namespace Todo.Domain.Commands
{
    public class UpdateTaskCommand( string title , string user, Guid id, string description , AbstractValidator<UpdateTaskCommand> validator ) : Command<UpdateTaskCommand>( validator ), ICommand
    {   
        public Guid Id { get;  set; } = id;
        public string Title { get;  set; } = title;
        public string Description { get;  set; } = description;
        public string User { get;  set; } = user;

    }
}
