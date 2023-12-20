using ToDo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Services;

public static class ToDoService
{
  static List<ToDoItem> ToDoItems { get; }

  static ToDoService()
  {
    ToDoItems = new List<ToDoItem>{
      new ToDoItem {Id = 1, DueDate = DateTime.Now, Task = "Testando todo list"}
    };

  }
  public static List<ToDoItem> GetAll() => ToDoItems;
  public static ToDoItem? Get(int id) => ToDoItems.FirstOrDefault(t => t.Id == id);
  public static void Add(ToDoItem toDoItem)
  {
    var nextId = ToDoItems.Count;
    toDoItem.Id = nextId+2;
    ToDoItems.Add(toDoItem);
  }
  public static void Update(ToDoItem toDoItem)
  {
    var index = ToDoItems.FindIndex(t => toDoItem.Id == t.Id);
    if (index == -1)
      return;

    ToDoItems[index] = toDoItem;
  }
  public static void Delete(int id)
  {
    var toDoItem = Get(id);
    if (toDoItem is null)
      return;

    ToDoItems.Remove(toDoItem);
  }
}