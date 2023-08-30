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

        [HttpGet]
        public IEnumerable<Todo> GetAll()
        {
            return _repository.GetAll("elvesbrito");
        }

        [HttpGet("done")]
        public IEnumerable<Todo> GetAllDone()
        {
            return _repository.GetAllDone("elvesbrito");
        }

        [HttpGet("undone")]
        public IEnumerable<Todo> GetAllUndone()
        {
            return _repository.GetAllUndone("elvesbrito");
        }

        [HttpGet("done/today")]
        public IEnumerable<Todo> GetDoneForToday()
        {
            return _repository.GetByPeriod
            (
                "elvesbrito",
                DateTime.Now.Date,
                true
            );
        }

        [HttpGet("undone/today")]
        public IEnumerable<Todo> GetUndoneForToday()
        {
            return _repository.GetByPeriod
            (
                "elvesbrito",
                DateTime.Now.Date,
                false
            );
        }

        [HttpGet("done/tomorrow")]
        public IEnumerable<Todo> GetDoneForTomorrow()
        {
            return _repository.GetByPeriod
            (
                "elvesbrito",
                DateTime.Now.Date.AddDays(1),
                true
            );
        }

        [HttpGet("undone/tomorrow")]
        public IEnumerable<Todo> GetUndoneForTomorrow()
        {
            return _repository.GetByPeriod
            (
                "elvesbrito",
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
