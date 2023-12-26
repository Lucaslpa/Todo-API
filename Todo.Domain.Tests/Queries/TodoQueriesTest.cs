

using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.Queries
{
    [TestClass]
    public class TodoQueriesTest
    {

        private readonly  List<TodoItem> _items ;

        private  Guid idTaskMatheus;
        public TodoQueriesTest()
        {
            _items = [];
            CreateFakeData();
        }

        void CreateFakeData()
        {
            _items.Add( new TodoItem( "Titulo da tarefa 1" , "Yan" , System.DateTime.Now.AddDays(-2) , "Descrição da tarefa 1" ) );
            _items.Add( new TodoItem( "Titulo da tarefa 3" , "João" , DateTime.Now , "Descrição da tarefa 3" ) );
            _items.Add( new TodoItem( "Titulo da tarefa 4" , "Matheus" , DateTime.Now , "Descrição da tarefa 4" ) );
            _items.Add( new TodoItem( "Titulo da tarefa 5" , "João" , DateTime.Now , "Descrição da tarefa 5" ) );
            SaveTaskId();
            AddDoneTask();
        }       

        void SaveTaskId()
        {
            var matheusItem = new TodoItem( "Titulo da tarefa 4" , "Matheus" , System.DateTime.Now , "Descrição da tarefa 4" );
            idTaskMatheus = matheusItem.Id;
            _items.Add( matheusItem );
        }

        void AddDoneTask()
        {
            var task = new TodoItem( "Titulo da tarefa 6" , "Matheus" , System.DateTime.Now , "Descrição da tarefa 6" );
            task.MarkAsDone();
            _items.Add( task );
        }


        [TestMethod]
        public void Should_get_all_tasks_from_one_user()
        {
            var result = _items.AsQueryable().Where( TodoItemQueries.GetAllByUser( "Yan" ) );
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Should_get_One_task_by_id()
        {
            var result = _items.AsQueryable().Where( TodoItemQueries.GetOneByUser( idTaskMatheus , "Matheus" ) );
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void Should_not_get_One_task_by_id_if_user_is_wrong()
        {
            var result = _items.AsQueryable().Where( TodoItemQueries.GetOneByUser( idTaskMatheus , "Jõao" ) );
            Assert.AreEqual( 0 , result.Count() );
        }

        [TestMethod]
        public void Should_get_all_tasks_undone_by_user()
        {
            var result = _items.AsQueryable().Where( TodoItemQueries.GetAllUndoneByUser( "Matheus" ) );
            Assert.AreEqual( 2 , result.Count() );
        }

        [TestMethod]
        public void Should_get_all_tasks_done_by_user()
        {
            var result = _items.AsQueryable().Where( TodoItemQueries.GetAllDoneByUser( "Matheus" ) );
            var result2 = _items.AsQueryable().Where( TodoItemQueries.GetAllDoneByUser( "Yan" ) );

            Assert.AreEqual( 1 , result.Count() );
            Assert.AreEqual( 0 , result2.Count() );
        }

        [TestMethod]
        public void Should_get_all_tasks_by_date()
        {
            var result = _items.AsQueryable().Where( TodoItemQueries.GetAllByDateAndUser( System.DateTime.Now , "Matheus" ) );
            var result2 = _items.AsQueryable().Where( TodoItemQueries.GetAllByDateAndUser( System.DateTime.Now , "João" ) );
            var result3 = _items.AsQueryable().Where( TodoItemQueries.GetAllByDateAndUser( System.DateTime.Now.AddDays( -2 ) , "Yan" ) );

            Assert.AreEqual( 3 , result.Count() );
            Assert.AreEqual( 2 , result2.Count() );
            Assert.AreEqual( 1 , result3.Count() );
        }

    }
}
