
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Mocks;
using Todo.Domain.Validators.Commands;

namespace Todo.Domain.Tests.Handlers
{
    [TestClass]
    public class ChangeTodoItemToUncompletedHandlersTest
    {
        private readonly ChangeToUncompletTaskCommand _invalidCommand = new(Guid.Empty, "", new ChangeToUncompletTaskCommandValidator());

        private readonly ChangeToUncompletTaskCommand _validCommand = new(Guid.NewGuid(), "Usuario", new ChangeToUncompletTaskCommandValidator());

        private readonly TodoHandler _handler = new(new ITodoItemRepositoryMock());


        [TestMethod]
        public void Should_Return_Invalid_When_ChangeToUncompletTaskCommand_Is_Invalid()
        {
            var result =  _handler.Handle(_invalidCommand);
            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Should_Return_Valid_When_ChangeToUncompletTaskCommand_Is_Valid()
        {   
            var result = _handler.Handle(_validCommand);
            Assert.AreEqual( result.Success, true);
        }
    }
}
