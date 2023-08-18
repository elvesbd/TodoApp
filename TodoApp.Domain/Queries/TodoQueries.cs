using System.Linq.Expressions;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Queries;

public static class TodoQueries
{
    public static Expression<Func<Todo, bool>> GetAll(string user)
    {
        return x => x.User == user;
    }

    public static Expression<Func<Todo, bool>> GetAllDone(string user)
    {
        return x => x.User == user && x.Done;
    }
}