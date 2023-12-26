
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler( ITodoItemRepository taskRepository ) : IHandler<CreateNewTaskCommand>, 
                               IHandler<ChangeToCompletedTaskCommand>, 
                               IHandler<ChangeToUncompletTaskCommand>, 
                               IHandler<UpdateTaskCommand>
    {


        private ITodoItemRepository _repository { get; set; } = taskRepository;

        public IGenericResult Handle( CreateNewTaskCommand command )
        {
            if( !command.Validate())
                return new CommandGenericResult(false, "Ops, parece que sua tarefa está errada!", command.GetNotifications());

            var task = new TodoItem( command.Title! , command.User! , command.Date, command.Description! );

            _repository.Create(task);
           
            return new CommandGenericResult(true, "Tarefa salva com sucesso!", task);
        }
        public IGenericResult Handle( ChangeToUncompletTaskCommand command )
        {
            if (!command.Validate())
                return new CommandGenericResult( false , "Ops, parece que sua tarefa está errada!" , command.GetNotifications() );

            var todoItem = _repository.Get(command.Id, command.User);

            if(todoItem == null)
                return new CommandGenericResult( false , "Tarefa não encontrada!" );

            if(todoItem.User != command.User)
                return new CommandGenericResult( false , "Usuário não encontrado!" );

            todoItem.MarkAsUndone();

            _repository.Update(todoItem);

            return new CommandGenericResult( true , "Tarefa salva com sucesso!" , todoItem );

        }
        public IGenericResult Handle( ChangeToCompletedTaskCommand command )
        {
            if (!command.Validate())
                return new CommandGenericResult( false , "Ops, parece que sua tarefa está errada!" , command.GetNotifications() );

            var todoItem = _repository.Get( command.Id, command.User );

            if (todoItem == null)
                return new CommandGenericResult( false , "Tarefa não encontrada!" );

            if (todoItem.User != command.User)
                return new CommandGenericResult( false , "Usuário não encontrado!" );

            todoItem.MarkAsDone();

            _repository.Update( todoItem );

            return new CommandGenericResult( true , "Tarefa salva com sucesso!" , todoItem );
        }
        public IGenericResult Handle( UpdateTaskCommand command )
        {
            
            if (!command.Validate())
                return new CommandGenericResult( false , "Ops, parece que sua tarefa está errada!" , command.GetNotifications() );

            var todoItem = _repository.Get( command.Id, command.User );

            if (todoItem == null)
                return new CommandGenericResult( false , "Tarefa não encontrada!" );

            if(!isFieldEmpty( command.Title ))
               todoItem.UpdateTitle( command.Title );

            if (!isFieldEmpty( command.Description ))
                todoItem.UpdateDescription( command.Description );

            todoItem.UpdateDate(DateTime.Now.Date);  

            _repository.Update( todoItem );

            return new CommandGenericResult( true , "Tarefa salva com sucesso!" , todoItem );   

        }

        private  bool isFieldEmpty( string field )
        {
            return field == null;
        }
    }
}
