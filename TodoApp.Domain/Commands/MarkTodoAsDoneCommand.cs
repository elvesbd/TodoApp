using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands.Interfaces;

namespace TodoApp.Domain.Commands;

public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsDoneCommand()
    { }

    public MarkTodoAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<MarkTodoAsDoneCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(User, 6, "User", "Invalid user!")
        );
    }
}
