using ToDo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Services;

public static class ToDoService
{
  private static List<ToDoItem> ToDoItems { get; }

  static ToDoService()
  {
    ToDoItems = new List<ToDoItem>{
      new ToDoItem {Id = 1, DueDate = DateTime.Now, Task = "Testando todo list"}
    };

  }
  public static List<ToDoItem> GetAll() => ToDoItems;
  public static ToDoItem? Get(int id) => ToDoItems.Find(t => t.Id == id);
  public static void Add(ToDoItem toDoItem)
  {
    var nextId = ToDoItems.Count;
    toDoItem.Id = nextId+2;
    ToDoItems.Add(toDoItem);
  }
  public static void Update(int id, [FromBody] ToDoItem toDoItem)
  {
    var existingItem = ToDoItems.Find(t => id == t.Id);
    if (existingItem is not null)
    {
      existingItem.Id = id;
      existingItem.DueDate = toDoItem.DueDate ?? existingItem.DueDate;
      existingItem.Project = toDoItem.Project ?? existingItem.Project;
      existingItem.Task = toDoItem.Task ?? existingItem.Task;
    }
  }
  public static void Delete(int id)
  {
    var toDoItem = Get(id);
    if (toDoItem is null)
      return;

    ToDoItems.Remove(toDoItem);
  }
}