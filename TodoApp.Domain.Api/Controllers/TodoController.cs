using Microsoft.AspNetCore.Mvc;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Controllers;

[ApiController]
public class TodoController : ControllerBase
{
    private readonly TodoHandler _handler;
    private readonly ITodoRepository _repository;
    public TodoController(TodoHandler handler, ITodoRepository repository)
    {
        _handler = handler;
        _repository = repository;
    }

    [HttpGet("v1/todos")]
    public IEnumerable<Todo> GetAll()
    {
        return _repository.GetAll("elvesbrito");
    }

    [HttpPost("v1/todos")]
    public GenericCommandResult Create([FromBody] CreateTodoCommand command)
    {
        command.User = "elvesbrito";
        return (GenericCommandResult)_handler.Handle(command);
    }
}