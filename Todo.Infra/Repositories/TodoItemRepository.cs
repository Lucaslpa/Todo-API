
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;

namespace Todo.Infra.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {

        private readonly SqlServerContext _context;

        public TodoItemRepository( SqlServerContext context )
        {
            _context = context;
        }

        public void Create( TodoItem todo )
        {
            _context.TodoItems.Add( todo );
            _context.SaveChanges();
        }

        public void Delete( TodoItem todo )
        {
            _context.Remove( todo );
            _context.SaveChanges();
        }

        public void Delete( Guid id )
        {
            _context.Remove( id );
            _context.SaveChanges();

        }

        public TodoItem? Get( TodoItem todo , string user )
        {
            var result = _context.TodoItems.AsNoTracking().FirstOrDefault( TodoItemQueries.GetOneByUser( todo.Id , user ) );
            return result;
        }

        public TodoItem? Get( Guid id , string user )
        {
            var result = _context.TodoItems.AsNoTracking().FirstOrDefault( TodoItemQueries.GetOneByUser( id , user ) );
            return result;
        }

        public IEnumerable<TodoItem> GetAllByDateAndUser( DateTime date , string User )
        {
            var result = _context.TodoItems.AsNoTracking().Where( TodoItemQueries.GetAllByDateAndUser( date , User ) );
            return result;
        }

        public IEnumerable<TodoItem> GetAllByUser( string User )
        {
            var result = _context.TodoItems.AsNoTracking().Where( TodoItemQueries.GetAllByUser( User ) );
            return result;
        }

        public IEnumerable<TodoItem> GetAllDoneByUser( string User )
        {
            var result = _context.TodoItems.AsNoTracking().Where( TodoItemQueries.GetAllDoneByUser( User ) );
            return result;
        }

        public IEnumerable<TodoItem> GetAllUndoneByUser( string User )
        {
            var result = _context.TodoItems.AsNoTracking().Where( TodoItemQueries.GetAllUndoneByUser( User ) );
            return result;
        }

        public void Update( TodoItem todo )
        {
            _context.Entry( todo ).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
