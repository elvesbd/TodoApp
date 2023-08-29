using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ITodoRepository
{
    void Create(Todo todo);
    void Update(Todo todo);
    Todo GetById(Guid id, string user);
    IEnumerable<Todo> GetAll(string user);
    IEnumerable<Todo> GetAllDone(string user);
    IEnumerable<Todo> GetAllUndone(string user);
    IEnumerable<Todo> GetByPeriod(string user, DateTime date, bool done);
}