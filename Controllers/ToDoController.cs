using ToDo.Models;
using ToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[ApiController]
[Route("[controller]")]

public class ToDoController : ControllerBase
{
  public ToDoController()
  {
  }

  [HttpGet]
  public ActionResult<List<ToDoItem>> GetAll() =>
    ToDoService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<ToDoItem> Get(int id)
  {
    var ToDo = ToDoService.Get(id);

    if (ToDo == null)
      return NotFound();

    return ToDo;
  }
}