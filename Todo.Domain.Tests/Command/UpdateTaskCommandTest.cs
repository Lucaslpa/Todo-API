using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Validators.Commands;

namespace Todo.Domain.Tests.Command
{
    internal class UpdateTaskCommandTest
    {
         
        private readonly UpdateTaskCommand _invalidCommand = new( "" , "" ,new Guid(), "" , new UpdateTaskCommandValidator() );

        private readonly UpdateTaskCommand _validCommand = new( "Devo tomar água" , "João" , new Guid() , "Devo tomar água para evitar pedra nos rins" , new UpdateTaskCommandValidator() );


        [TestMethod]
        public void Should_Return_Invalid_When_UpdateTaskCommand_Is_Invalid()
        {
            Assert.AreEqual( _invalidCommand.Validate(), false);
        }

        public void Should_Return_Valid_When_UpdateTaskCommand_Is_Valid()
        {
            Assert.AreEqual( _validCommand.Validate() , true );
        }

    }
}
