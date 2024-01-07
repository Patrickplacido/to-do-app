using Microsoft.EntityFrameworkCore;
using ToDo.Models;

namespace ToDo.Data;

public class ToDoDbContext : DbContext
{
  public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options) { }
  public DbSet<ToDoItem>? ToDoItems { get; set; }
}