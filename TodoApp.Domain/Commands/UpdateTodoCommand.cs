using Flunt.Notifications;
using Flunt.Validations;
using TodoApp.Domain.Commands.Interfaces;

namespace TodoApp.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    public UpdateTodoCommand()
    { }

    public UpdateTodoCommand(Guid id, string title, string user)
    {
        Id = id;
        Title = title;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string User { get; set; }

    public void Validate()
    {
        AddNotifications(
            new Contract<UpdateTodoCommand>()
                .Requires()
                .IsGreaterOrEqualsThan(Title, 3, "Title", "Por favor, descreva melhor esta tarefa!")
                .IsGreaterOrEqualsThan(User, 6, "User", "Invalid user!")
        );
    }
}