using Microsoft.AspNetCore.Mvc;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Services
{
  public class ToDoService
  {
    private readonly ToDoDbContext _context;

    public ToDoService(ToDoDbContext dbContext)
    {
      _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public List<ToDoItem> GetAll() => _context.ToDoItems.ToList();

    public ToDoItem Get(int id) => _context.ToDoItems.Find(id);

    public void Add(ToDoItem toDoItem)
    {
      _context.ToDoItems.Add(toDoItem);
      _context.SaveChanges();
    }

    public void Update(int id, [FromBody] ToDoItem toDoItem)
    {
      var existingItem = _context.ToDoItems.Find(id);
      if (existingItem is not null)
      {
        existingItem.Id = id;
        existingItem.DueDate = toDoItem.DueDate ?? existingItem.DueDate;
        existingItem.Project = toDoItem.Project ?? existingItem.Project;
        existingItem.Task = toDoItem.Task ?? existingItem.Task;
        _context.SaveChanges();
      }
    }

    public void Delete(int id)
    {
      var toDoItem = _context.ToDoItems.Find(id);
      if (toDoItem is not null)
      {
        _context.ToDoItems.Remove(toDoItem);
        _context.SaveChanges();
      }
    }
  }
}