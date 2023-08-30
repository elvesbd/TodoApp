using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Infra.Contexts;
using TodoApp.Domain.Infra.Repositories;
using TodoApp.Domain.Repositories;


namespace TodoApp.Domain.Extensions;

public static class AppExtensions
{
    public static void ConfigureMvc(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
    }

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DataContext>(opt =>
            opt.UseSqlServer(connectionString)
        );
        builder.Services.AddTransient<ITodoRepository, TodoRepository>();
        builder.Services.AddTransient<TodoHandler, TodoHandler>();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}