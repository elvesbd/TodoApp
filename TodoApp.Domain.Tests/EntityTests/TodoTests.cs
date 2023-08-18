using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Tests.EntityTests;

[TestClass]
public class TodoTests
{
    [TestMethod]
    public void Given_creating_a_todo_done_must_be_false()
    {
        var todo = new Todo("Create Repo", "Elves Brito", DateTime.Now);
        Assert.IsFalse(todo.Done);
    }

    [TestMethod]
    public void Given_creating_a_todo_marked_as_done_done_should_be_true()
    {
        var todo = new Todo("Create Repo", "Elves Brito", DateTime.Now);
        todo.MarkAsDone();
        Assert.IsTrue(todo.Done);
    }

    [TestMethod]
    public void Given_marking_a_todo_as_undone_done_should_be_false()
    {
        var todo = new Todo("Create Repo", "Elves Brito", DateTime.Now, true);
        todo.MarkAsUndone();
        Assert.IsFalse(todo.Done);
    }

    [TestMethod]
    public void Given_updating_todo_title_new_title_should_be_set()
    {
        var todo = new Todo("Create Repo", "Elves Brito", DateTime.Now, true);
        todo.UpdateTitle("Update Repo");
        Assert.AreEqual(todo.Title, "Update Repo");
    }
}