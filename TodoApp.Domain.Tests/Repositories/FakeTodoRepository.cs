using TodoApp.Domain.Entities;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Tests.Repositories;

public class FakeTodoRepository : ITodoRepository
{
    public Todo GetById(Guid id, string user)
    {
        return new Todo("Todo Title", "Elves Brito", DateTime.Now);
    }

    public void Create(Todo todo)
    {

    }

    public void Update(Todo todo)
    {

    }
}