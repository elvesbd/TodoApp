using Flunt.Notifications;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Commands.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers.Interfaces;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Handlers;

public class TodoHandler : Notifiable<Notification>, IHandler<CreateTodoCommand>
{
    private readonly ITodoRepository _repository;

    public TodoHandler(ITodoRepository repository)
    {
        _repository = repository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult
            (
                false,
                "Ops, parece que sua tarefa está errada!",
                command.Notifications
            );

        var todo = new Todo(command.Title, command.User, command.Date);
        _repository.Create(todo);
        return new GenericCommandResult(true, "Tarefa salva com sucesso!", todo);
    }
}