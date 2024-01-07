using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ToDo.Models;

public class ToDoItem
{
  public int Id { get; set; }
  public DateTime? DueDate { get; set; }
  public Project? Project { get; set; }
  public string Task { get; set; }
}