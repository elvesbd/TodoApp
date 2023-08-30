using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands.Interfaces;

namespace TodoApp.Domain.Commands;

public class MarkTodoAsUndoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsUndoneCommand()
    { }

    public MarkTodoAsUndoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<MarkTodoAsUndoneCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(User, 6, "User", "Invalid user!")
        );
    }
}
