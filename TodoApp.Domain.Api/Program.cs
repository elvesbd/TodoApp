using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Handlers;
using TodoApp.Domain.Infra.Contexts;
using TodoApp.Domain.Infra.Repositories;
using TodoApp.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("database"));
builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors
(
    x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
