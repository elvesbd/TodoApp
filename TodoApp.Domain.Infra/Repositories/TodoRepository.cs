using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;
using TodoApp.Domain.Infra.Contexts;
using TodoApp.Domain.Queries;
using TodoApp.Domain.Repositories;

namespace TodoApp.Domain.Infra.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly DataContext _context;
    public TodoRepository(DataContext context)
    {
        _context = context;
    }

    public void Create(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
    }

    public IEnumerable<Todo> GetAll(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAll(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<Todo> GetAllDone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllDone(user))
            .OrderBy(x => x.Date);
    }

    public IEnumerable<Todo> GetAllUndone(string user)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetAllUndone(user))
            .OrderBy(x => x.Date);
    }

    public Todo GetById(Guid id, string user)
    {
        return _context.Todos
            .FirstOrDefault(x => x.Id == id && x.User == user);
    }

    public IEnumerable<Todo> GetByPeriod(string user, DateTime date, bool done)
    {
        return _context.Todos
            .AsNoTracking()
            .Where(TodoQueries.GetByPeriod(user, date, done))
            .OrderBy(x => x.Date);
    }

    public void Update(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        _context.SaveChanges();
    }
}