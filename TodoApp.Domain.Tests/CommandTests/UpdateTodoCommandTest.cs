using TodoApp.Domain.Commands;

namespace TodoApp.Domain.Tests.CommandsTests;

[TestClass]
public class UpdateTodoCommandTests
{
    private readonly CreateTodoCommand _invalidCommand = new("", "", DateTime.Now);
    private readonly CreateTodoCommand _validCommand = new("Create Repo", "Elves Brito", DateTime.Now);

    [TestMethod]
    public void Given_an_invalid_command()
    {
        _invalidCommand.Validate();
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Given_an_valid_command()
    {
        _validCommand.Validate();
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}