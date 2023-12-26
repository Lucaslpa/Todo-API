using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Tests.Mocks
{
    public class ITodoItemRepositoryMock : ITodoItemRepository
    {   

        private readonly TodoItem _todoItem = new( "Titulo da tarefa" , "Usuario" , System.DateTime.Now , "Descrição da tarefa" );

        private readonly List<TodoItem> items = [];

       public ITodoItemRepositoryMock()
        {
            items.Add( new TodoItem( "Titulo da tarefa 1" , "Yan" , System.DateTime.Now.AddDays( -2 ) , "Descrição da tarefa 1" ) );
            items.Add( new TodoItem( "Titulo da tarefa 3" , "João" , DateTime.Now , "Descrição da tarefa 3" ) );
            items.Add( new TodoItem( "Titulo da tarefa 4" , "Matheus" , DateTime.Now , "Descrição da tarefa 4" ) );
            items.Add( new TodoItem( "Titulo da tarefa 5" , "João" , DateTime.Now , "Descrição da tarefa 5" ) );
        }

        public void Create( TodoItem todo )
        {
        }

        public void Delete( TodoItem todo )
        {
            throw new NotImplementedException();
        }

        public void Delete( Guid id )
        {
            
        }

        public TodoItem? Get( TodoItem todo, string user )
        {
            return _todoItem;
        }

        public TodoItem? Get( Guid id, string user )
        {
            return _todoItem;
        }

        public IEnumerable<TodoItem> GetAllByDateAndUser( DateTime date , string User )
        {
            return items;
        }

        public IEnumerable<TodoItem> GetAllByUser( string User )
        {
            return items;
        }

        public IEnumerable<TodoItem> GetAllDoneByUser( string User )
        {
            return items;   
         }

        public IEnumerable<TodoItem> GetAllUndoneByUser( string User )
        {
            return items;
        }

   
        public void Update( TodoItem todo )
        {
        }
    }
}
