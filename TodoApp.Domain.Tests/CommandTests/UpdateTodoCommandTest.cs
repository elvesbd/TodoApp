using TodoApp.Domain.Commands;

namespace TodoApp.Domain.Tests.CommandTests;

[TestClass]
public class UpdateTodoCommandTests
{
    private readonly UpdateTodoCommand _invalidCommand = new(Guid.NewGuid(), "", "");
    private readonly UpdateTodoCommand _validCommand = new(Guid.NewGuid(), "Todo Title", "Elves Brito");

    [TestMethod]
    public void Given_an_invalid_command_should_be_return_false()
    {
        _invalidCommand.Validate();
        Assert.IsFalse(_invalidCommand.IsValid);
    }

    [TestMethod]
    public void Given_an_valid_command_should_be_return_true()
    {
        _validCommand.Validate();
        Assert.IsTrue(_validCommand.IsValid);
    }
}