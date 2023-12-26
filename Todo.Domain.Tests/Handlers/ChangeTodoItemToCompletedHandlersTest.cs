using System.Reflection.Metadata;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Mocks;
using Todo.Domain.Validators.Commands;

namespace Todo.Domain.Tests.Handlers
{

    [TestClass]
    public class ChangeTodoItemToCompletedHandlersTest
    {

        private readonly ChangeToCompletedTaskCommand _invalidCommand = new( Guid.Empty , "" , new ChangeToCompletedTaskCommandValidator() );

        private readonly ChangeToCompletedTaskCommand _validCommand = new( Guid.NewGuid() , "Usuario" , new ChangeToCompletedTaskCommandValidator() );

        private readonly TodoHandler _handler = new(new ITodoItemRepositoryMock());

        [TestMethod]
        public void Should_return_false_when_command_is_invalid()
        {

            var result = _handler.Handle( _invalidCommand );
            Assert.AreEqual( result.Success , false );
        }

        [TestMethod]
        public void Should_change_TodoItem_To_Completed_with_success()
        {
            var result = _handler.Handle( _validCommand );
            Assert.AreEqual( result.Success , true );
        }   

    }
}
