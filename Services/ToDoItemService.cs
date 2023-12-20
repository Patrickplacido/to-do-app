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

}