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

  [HttpPost]
  public IActionResult Create(ToDoItem toDoItem)
  {
    ToDoService.Add(toDoItem);
    return CreatedAtAction(nameof(Get), new { id = toDoItem.Id }, toDoItem);
  }

  [HttpPut("{id}")]
  public IActionResult Update(int id, ToDoItem toDoItem)
  {
    if (id != toDoItem.Id)
      return BadRequest();

    var existingItem = ToDoService.Get(id);

    if (existingItem is null)
      return NotFound();

    ToDoService.Update(toDoItem);

    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var toDoItem = ToDoService.Get(id);

    if (toDoItem is null)
      return NotFound();

    ToDoService.Delete(id);

    return NoContent();
  }


}