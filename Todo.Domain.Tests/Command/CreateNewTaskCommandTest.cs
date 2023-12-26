

using Todo.Domain.Commands;

namespace Todo.Domain.Tests.Command
{
    [TestClass]
    public class CreateNewTaskCommandTest
    {
        private readonly CreateNewTaskCommand _invalidCommand = new( "" , "" , "" , new CreateNewTaskCommandValidator() );

        private readonly CreateNewTaskCommand _validCommand = new( "Deve tomar água" , "João" , "Preciso tomar água para evitar pedra nos rins" , new CreateNewTaskCommandValidator() );

        [TestMethod]
        public void Should_Return_Invalid_When_CreateNewTaskCommand_Is_Invalid()
        {
            Assert.AreEqual( _invalidCommand.Validate(), false);
        }

        [TestMethod]
        public void Should_Return_Valid_When_CreateNewTaskCommand_Is_Valid()
        {
            Assert.AreEqual( _validCommand.Validate() , true );
        }

    }
}
