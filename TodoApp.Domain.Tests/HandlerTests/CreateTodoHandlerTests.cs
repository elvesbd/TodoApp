using TodoApp.Domain.Commands;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Tests.Repositories;

namespace TodoApp.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{
    [TestMethod]
    public void Given_an_invalid_command_must_stop_execution()
    {
        var command = new CreateTodoCommand("", "", DateTime.Now);
        var handler = new TodoHandler(new FakeTodoRepository());
        var result = (GenericCommandResult)handler.Handle(command);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Given_an_valid_command_must_create_an_todo()
    {
        var command = new CreateTodoCommand("Create Repo", "Elves Brito", DateTime.Now);
        var handler = new TodoHandler(new FakeTodoRepository());
        var result = (GenericCommandResult)handler.Handle(command);
        Assert.AreEqual(result.Success, true);
    }
}