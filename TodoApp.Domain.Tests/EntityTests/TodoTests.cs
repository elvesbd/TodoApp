using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Tests.EntityTests;

[TestClass]
public class TodoTests
{
    private readonly Todo _todo = new("Create Repo", "Elves Brito", DateTime.Now);
    private readonly Todo _todoAsDone = new("Create Repo", "Elves Brito", DateTime.Now, true);

    [TestMethod]
    public void Given_creating_a_todo_done_must_be_false()
    {
        Assert.IsFalse(_todo.Done);
    }

    [TestMethod]
    public void Given_creating_a_todo_marked_as_done_done_should_be_true()
    {
        _todo.MarkAsDone();
        Assert.IsTrue(_todo.Done);
    }

    [TestMethod]
    public void Given_marking_a_todo_as_undone_done_should_be_false()
    {
        _todoAsDone.MarkAsUndone();
        Assert.IsFalse(_todoAsDone.Done);
    }

    [TestMethod]
    public void Given_updating_todo_title_new_title_should_be_set()
    {
        _todoAsDone.UpdateTitle("Update Repo");
        Assert.AreEqual(_todoAsDone.Title, "Update Repo");
    }
}