using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Domain.Infra.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Todo>? Todos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Todo>()
            .Property(x => x.Id)
        ;
        modelBuilder
            .Entity<Todo>()
            .Property(x => x.User)
            .HasMaxLength(120)
            .HasColumnType("varchar(120)")
        ;
        modelBuilder
            .Entity<Todo>()
            .Property(x => x.Title)
            .HasColumnType("varchar(160)")
        ;
        modelBuilder
            .Entity<Todo>()
            .Property(x => x.Done)
            .HasColumnType("bit")
        ;
        modelBuilder
            .Entity<Todo>()
            .Property(x => x.Date)
        ;
        modelBuilder
            .Entity<Todo>()
            .HasIndex(x => x.User)
        ;
    }
}