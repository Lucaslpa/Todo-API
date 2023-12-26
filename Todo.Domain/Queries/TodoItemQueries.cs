
using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries
{
    public static class TodoItemQueries 
    {
        public static Expression<Func<TodoItem, bool>> GetAllByUser(string User)
        {
               return x => x.User == User;
        }

        public static Expression<Func<TodoItem , bool>>GetOneByUser( Guid id, string User )
        {
            return x => x.Id == id && x.User == User;
        }

        public static Expression<Func<TodoItem , bool>> GetAllUndoneByUser( string User )
        {
            return x => x.Done == false && x.User == User;
        }

        public static Expression<Func<TodoItem , bool>> GetAllDoneByUser( string User )
        {
            return x => x.Done == true && x.User == User;
        }

        public static Expression<Func<TodoItem , bool>> GetAllByDateAndUser( DateTime date, string User )
        {
            return x => x.Date.DayOfYear == date.DayOfYear && x.User == User;
        }

    }
}
