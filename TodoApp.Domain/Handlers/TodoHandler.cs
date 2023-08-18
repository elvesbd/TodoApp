using Flunt.Notifications;
using TodoApp.Domain.Commands;
using TodoApp.Domain.Commands.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Handlers.Interfaces;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Handlers;

public class TodoHandler :
    Notifiable<Notification>,
    IHandler<CreateTodoCommand>,
    IHandler<UpdateTodoCommand>,
    IHandler<MarkTodoAsDoneCommand>
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

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult
            (
                false,
                "Ops, parece que sua tarefa está errada!",
                command.Notifications
            );

        var todo = _repository.GetById(command.Id, command.User);
        todo.UpdateTitle(command.Title);
        _repository.Update(todo);
        return new GenericCommandResult(true, "Tarefa salva con sucesso!", todo);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult
            (
                false,
                "Ops, parece que sua tarefa está errada!",
                command.Notifications
            );

        var todo = _repository.GetById(command.Id, command.User);
        todo.MarkAsDone();
        _repository.Update(todo);
        return new GenericCommandResult(true, "Tarefa salva con sucesso!", todo);
    }
}