using Todo.Domain.Commands;
using Todo.Domain.Validators.Commands;

namespace Todo.Domain.Tests.Command
{

    [TestClass]
    public class ChangeToCompletedTaskCommandTest
    {

        private readonly ChangeToCompletedTaskCommand _invalidCommand = new( Guid.Empty , "" , new ChangeToCompletedTaskCommandValidator() );

        private readonly ChangeToCompletedTaskCommand _validCommand = new( Guid.NewGuid() , "João" , new ChangeToCompletedTaskCommandValidator() );

        [TestMethod]
        public void Should_Return_Invalid_When_ChangeToCompletedTaskCommand_Is_Invalid()
        {
            Assert.AreEqual( _invalidCommand.Validate() , false );
        }

        [TestMethod]
        public void Should_Return_Valid_When_ChangeToCompletedTaskCommand_Is_Valid()
        {
            Assert.AreEqual( _validCommand.Validate() , true );
        }

    }
}
