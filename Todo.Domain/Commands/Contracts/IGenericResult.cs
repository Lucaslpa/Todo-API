

namespace Todo.Domain.Commands.Contracts
{
    public interface IGenericResult
    {
          bool Success { get; set; }
          string Message { get; set; }
          object? Data { get; set; }
    }
}
