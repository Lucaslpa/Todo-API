
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Mocks;
using Todo.Domain.Validators.Commands;

namespace Todo.Domain.Tests.Handlers
{
    [TestClass]
    public class UpdateTodoItemHandlersTest
    {   
        private readonly UpdateTaskCommand _invalidCommand = new( "" , "", new Guid() ,"" ,  new UpdateTaskCommandValidator() );

        private readonly UpdateTaskCommand _validCommand = new( "Devo tomar água 2 vezes" , "João" , new Guid( "67d98540-a33a-4712-a985-1adeb7354256" ) , "Minha nova descrição" , new UpdateTaskCommandValidator() );
        
        private readonly TodoHandler _handler = new(new ITodoItemRepositoryMock());

        [TestMethod]
        public void Should_return_false_when_command_is_invalid()
        {
            var result = _handler.Handle( _invalidCommand );
            Assert.AreEqual( result.Success , false);
        }

        [TestMethod]
        public void Should_return_update_todoItem_when_command_is_valid()
        {
            var result = _handler.Handle( _validCommand );

            Assert.AreEqual( true , result.Success );
        }
    }
}
