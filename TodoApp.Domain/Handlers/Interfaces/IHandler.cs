using TodoApp.Domain.Commands.Interfaces;

namespace TodoApp.Domain.Handlers.Interfaces;

public interface IHandler<T> where T : ICommand
{
    ICommandResult Handle(T command);
}