

using Todo.Domain.Commands;
using Todo.Domain.Validators.Commands;

namespace Todo.Domain.Tests.Command
{

    [TestClass]
    public class ChangeToUncompletTaskCommandTest
    {   

        private readonly ChangeToUncompletTaskCommand _invalidCommand = new( Guid.Empty , "" , new ChangeToUncompletTaskCommandValidator() );

        private readonly ChangeToUncompletTaskCommand _validCommand = new( Guid.NewGuid() , "João" , new ChangeToUncompletTaskCommandValidator() );

        [TestMethod]
        public void Should_Return_Invalid_When_ChangeToUncompletTaskCommand_Is_Invalid()
        {
            Assert.AreEqual( _invalidCommand.Validate() , false );
        }

        [TestMethod]
        public void Should_Return_Valid_When_ChangeToUncompletTaskCommand_Is_Valid()
        {
            Assert.AreEqual( _validCommand.Validate() , true );
        }

    }
}
