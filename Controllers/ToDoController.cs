using ToDo.Models;
using ToDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers;

[ApiController]
[Route("[controller]")]

public class ToDoController : ControllerBase
{
  public ToDoService _toDoService;

  public ToDoController(ToDoService toDoService)
  {
    _toDoService = toDoService ?? throw new ArgumentNullException(nameof(toDoService));
  }

  [HttpGet]
  public ActionResult<List<ToDoItem>> GetAll() =>
    _toDoService.GetAll();

  [HttpGet("{id}")]
  public ActionResult<ToDoItem> Get(int id)
  {
    var ToDo = _toDoService.Get(id);

    if (ToDo == null)
      return NotFound();

    return ToDo;
  }

  [HttpPost]
  public IActionResult Create(ToDoItem toDoItem)
  {
    _toDoService.Add(toDoItem);
    return CreatedAtAction(nameof(Get), new { id = toDoItem.Id }, toDoItem);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, ToDoItem toDoItem)
  {
    var existingItem = _toDoService.Get(id);

    if (existingItem is null)
      return NotFound();

    _toDoService.Update(id, toDoItem);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var toDoItem = _toDoService.Get(id);

    if (toDoItem is null)
      return NotFound();

    _toDoService.Delete(id);

    return NoContent();
  }


}