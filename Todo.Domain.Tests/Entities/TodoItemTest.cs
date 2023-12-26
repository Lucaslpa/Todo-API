

using Todo.Domain.Entities;

namespace Todo.Domain.Tests.Entities
{   
    [TestClass]
    public class TodoItemTest
    {
        private readonly TodoItem _todoItem = new( "Titulo da tarefa" , "Usuario" , System.DateTime.Now , "Descrição da tarefa" );


        [TestMethod]
        public void Should_mark_as_done()
        {
            var todoItem = _todoItem;
            todoItem.MarkAsDone();
            Assert.AreEqual( todoItem.Done , true );
        }

        [TestMethod]
        public void Should_mark_as_undone()
        {
            var todoItem = _todoItem;
            todoItem.MarkAsUndone();
            Assert.AreEqual( todoItem.Done , false );
        }

        [TestMethod]
        public void Should_update_title()
        {
            var todoItem = _todoItem;
            todoItem.UpdateTitle( "Titulo atualizado" );
            Assert.AreEqual( todoItem.Title , "Titulo atualizado" );
        }

        [TestMethod]
        public void Should_update_description()
        {
            var todoItem = _todoItem;
            todoItem.UpdateDescription( "Descrição atualizada" );
            Assert.AreEqual( todoItem.Description , "Descrição atualizada" );
        }

        [TestMethod]
        public void Should_update_date()
        {
            var todoItem = _todoItem;
            var date = System.DateTime.Now;
            todoItem.UpdateDate( date );
            Assert.AreEqual( todoItem.Date , date );
        }

    }
}
