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

    public IEnumerable<Todo> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Todo> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Todo> GetAllUndone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Todo> GetByPeriod(string user, DateTime date, bool done)
    {
        throw new NotImplementedException();
    }
}