using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        private readonly TodoHandler _handler;
        private readonly ITodoRepository _repository;

        public TodoController(TodoHandler handler, ITodoRepository repository)
        {
            _handler = handler;
            _repository = repository;
        }

        [HttpGet("user/{user}")]
        public IEnumerable<Todo> GetAll([FromRoute] string user)
        {
            return _repository.GetAll(user);
        }

        [HttpGet("done/{user}")]
        public IEnumerable<Todo> GetAllDone([FromRoute] string user)
        {
            return _repository.GetAllDone(user);
        }

        [HttpGet("undone/{user}")]
        public IEnumerable<Todo> GetAllUndone([FromRoute] string user)
        {
            return _repository.GetAllUndone(user);
        }

        [HttpGet("done/today/{user}")]
        public IEnumerable<Todo> GetDoneForToday([FromRoute] string user)
        {
            return _repository.GetByPeriod
            (
                user,
                DateTime.Now.Date,
                true
            );
        }

        [HttpGet("undone/today/{user}")]
        public IEnumerable<Todo> GetUndoneForToday([FromRoute] string user)
        {
            return _repository.GetByPeriod
            (
                user,
                DateTime.Now.Date,
                false
            );
        }

        [HttpGet("done/tomorrow/{user}")]
        public IEnumerable<Todo> GetDoneForTomorrow([FromRoute] string user)
        {
            return _repository.GetByPeriod
            (
                user,
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [HttpGet("undone/tomorrow/{user}")]
        public IEnumerable<Todo> GetUndoneForTomorrow([FromRoute] string user)
        {
            return _repository.GetByPeriod
            (
                user,
                DateTime.Now.Date.AddDays(1),
                false
            );
        }

        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand command)
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateTodoCommand command)
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        [HttpPut("mark-as-done")]
        public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command)
        {
            return (GenericCommandResult)_handler.Handle(command);
        }

        [HttpPut("mark-as-undone")]
        public GenericCommandResult MarkAsUndone([FromBody] MarkTodoAsUndoneCommand command)
        {
            return (GenericCommandResult)_handler.Handle(command);
        }
    }
}
