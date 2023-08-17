using TodoApp.Domain.Commands;

namespace TodoApp.Domain.Tests.CommandsTests;

[TestClass]
public class CreateTodoCommandTests
{
    [TestMethod]
    public void Given_an_invalid_command()
    {
        var command = new CreateTodoCommand("", "", DateTime.Now);
        command.Validate();
        Assert.AreEqual(command.IsValid, false);
    }
}