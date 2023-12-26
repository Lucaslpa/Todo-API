using FluentValidation;
using System.Text.Json.Serialization;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CreateNewTaskCommand( string title , string user , string description , CreateNewTaskCommandValidator validator ) : Command<CreateNewTaskCommand>( validator ), ICommand
    {
        public string? Title { get; set; } = title;
        public string? User { get; set; } = user;
        public DateTime Date { get; set; } = DateTime.Now.Date;
        public string? Description { get; set; } = description;

    }
}
