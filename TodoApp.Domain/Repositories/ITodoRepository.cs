using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Repositories;

public interface ITodoRepository
{
    void Create(Todo todo);
    void Update(Todo todo);
    Todo GetById(Guid id, string user);
}