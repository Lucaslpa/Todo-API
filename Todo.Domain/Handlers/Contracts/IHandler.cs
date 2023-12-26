using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Handlers.Contracts
{
    internal interface IHandler<in T> where T : ICommand
    {
        public IGenericResult Handle( T command );
    }
}
