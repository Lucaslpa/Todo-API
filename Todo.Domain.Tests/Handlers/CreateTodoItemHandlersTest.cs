using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Mocks;

namespace Todo.Domain.Tests.Handlers
{
    [TestClass]
    public class CreateTodoItemHandlersTest
    {

        private readonly CreateNewTaskCommand _invalidCommand = new("", "", "", new CreateNewTaskCommandValidator());

        private readonly CreateNewTaskCommand _validCommand = new("Deve tomar água", "João", "Preciso tomar água para evitar pedra nos rins", new CreateNewTaskCommandValidator());


        private readonly TodoHandler _handler = new(new ITodoItemRepositoryMock());

        [TestMethod]
        public void Should_return_false_when_command_is_invalid()
        {
            var result = _handler.Handle(_invalidCommand);

            Assert.AreEqual(result.Success, false);
        }

        [TestMethod]
        public void Should_return_true_when_command_is_valid()
        {
            var result = _handler.Handle(_validCommand);
            Assert.AreEqual(result.Success, true);
        }


    }
}
