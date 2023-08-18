using TodoApp.Domain.Commands;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Tests.Repositories;

namespace TodoApp.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand = new("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new("Create Repo", "Elves Brito", DateTime.Now);
    private readonly TodoHandler _handler = new(new FakeTodoRepository());

    [TestMethod]
    public void Given_an_invalid_command_must_stop_execution()
    {
        var result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Given_an_valid_command_must_create_an_todo()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(result.Success, true);
    }
}