
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands
{
    public class CommandGenericResult( bool success , string message , object? data = null ) : IGenericResult
    {
        public bool Success { get; set; } = success;
        public string Message { get; set; } = message;
        public object? Data { get; set; } = data;
    }
}
