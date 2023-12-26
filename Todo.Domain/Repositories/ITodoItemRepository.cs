using System.Linq.Expressions;
using Todo.Domain.Entities;
using Todo.Domain.Repositories.Contracts;

namespace Todo.Domain.Repositories
{
    public interface ITodoItemRepository : IRepository
    {
        public void Create( TodoItem todo );
        public TodoItem? Get( TodoItem todo, string user );
        public TodoItem? Get( Guid id, string user );
        public void Update( TodoItem todo );
        public void Delete( TodoItem todo );
        public void Delete( Guid id );
        public IEnumerable<TodoItem> GetAllByUser( string User );
        public IEnumerable<TodoItem> GetAllUndoneByUser( string User );
        public IEnumerable<TodoItem> GetAllDoneByUser( string User );
        public IEnumerable<TodoItem> GetAllByDateAndUser( DateTime date , string User );

    }
}
