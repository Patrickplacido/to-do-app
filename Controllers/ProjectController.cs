using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Services;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        public ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        [HttpGet]
        public ActionResult<List<Project>> GetAll() =>
            _projectService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Project> Get(int id)
        {
            var Project = _projectService.Get(id);

            if (Project == null)
                return NotFound();

            return Project;
        }

        [HttpPost]
        public IActionResult Create(Project project)
        {
            _projectService.Add(project);
            return CreatedAtAction(nameof(Get), new { id = project.Id }, project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            var existingProject = _projectService.Get(id);

            if (existingProject is null)
                return NotFound();

            _projectService.Update(id, project);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _projectService.Get(id);

            if (project is null)
                return NotFound();

            _projectService.Delete(id);

            return NoContent();
        }


    }
}