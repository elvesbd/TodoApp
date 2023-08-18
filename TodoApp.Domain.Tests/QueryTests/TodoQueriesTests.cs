using TodoApp.Domain.Entities;
using TodoApp.Domain.Queries;

namespace TodoApp.Domain.Tests.QueryTests;

[TestClass]
public class TodoQueriesTests
{
    private List<Todo> _todos;

    public TodoQueriesTests()
    {
        _todos = new List<Todo>
        {
            new Todo("Title 1", "User A", DateTime.Now),
            new Todo("Title 2", "User B", DateTime.Now),
            new Todo("Title 3", "User C", DateTime.Now),
            new Todo("Title 4", "User D", DateTime.Now),
            new Todo("Title 5", "User A", DateTime.Now)
        };
    }

    [TestMethod]
    public void Must_return_all_todos_of_the_informed_user()
    {
        var result = _todos.AsQueryable().Where(TodoQueries.GetAll("User A"));
        Assert.AreEqual(result.Count(), 2);
    }
}