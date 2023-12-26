using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Api.ViewModel.TodoItem;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using Todo.Domain.Validators.Commands;

namespace Todo.Api.Controllers
{
    [ApiController]
    [Route("v1/Todos")]
    [Authorize]
    public class TodoControllers( ITodoItemRepository repository , TodoHandler handler ) : ControllerBase
    {

        private readonly ITodoItemRepository _repository = repository;
        private readonly TodoHandler _handler = handler;

        [HttpGet]
        [Route("")]
        public IEnumerable<TodoItem> GetAll()
        {  
            var user = User.Claims.FirstOrDefault(x => x.Type == "user_id")?.Value;
            return _repository.GetAllByUser( user );
        }

        [HttpGet]
        [Route( "Done" )]
        public IEnumerable<TodoItem> GetAllDone() {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return _repository.GetAllDoneByUser( user );
        }

        [HttpGet]
        [Route( "Undone" )]
        public IEnumerable<TodoItem> GetAllUndone( )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return _repository.GetAllUndoneByUser( user );
        }

        [HttpGet]
        [Route( "Date/{date}" )]
        public IEnumerable<TodoItem> GetAllByDate( string date )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            var Date = DateTime.Parse( date );
            return _repository.GetAllByDateAndUser( Date , user );
        }

        [HttpGet]
        [Route( "{id}" )]
        public TodoItem GetOne(  Guid id )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return _repository.Get( id , user );
        }

        [HttpPost]
        [Route( "" )]
        public CommandGenericResult Post( [FromBody] CreateTaskCommandViewModel commandViewModal, [FromServices] CreateNewTaskCommandValidator validator )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;

            var command = new CreateNewTaskCommand( commandViewModal.Title ,user,commandViewModal.Description , validator );
            return (CommandGenericResult)_handler.Handle( command );
        }

        [HttpPut]
        [Route( "{id}" )]
        public CommandGenericResult Put( Guid id , [FromBody] UpdateTaskCommandViewModel commandViewModal , [FromServices] UpdateTaskCommandValidator validator )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;

            var command = new UpdateTaskCommand( commandViewModal.Title , user , id , commandViewModal.Description , validator );
            return (CommandGenericResult)_handler.Handle( command );
        }

        [HttpPut]
        [Route( "MarkAsDone/{id}" )]
        public CommandGenericResult MarkAsCompleted( Guid id , [FromServices] ChangeToCompletedTaskCommandValidator validator )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;

            var command = new ChangeToCompletedTaskCommand( id , user , validator );
            return (CommandGenericResult)_handler.Handle( command );
        }

        [HttpPut]
        [Route( "MarkAsUndone/{id}" )]
        public CommandGenericResult MarkAsUncompleted( Guid id , [FromServices] ChangeToUncompletTaskCommandValidator validator )
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;

            var command = new ChangeToUncompletTaskCommand( id , user , validator );
            return (CommandGenericResult)_handler.Handle( command );
        }
       
    }
}
