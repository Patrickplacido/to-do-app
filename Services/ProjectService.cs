using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ToDo.Data;
using ToDo.Models;

namespace ToDo.Services
{
    public class ProjectService
    {
        private readonly ToDoDbContext _context;

        public ProjectService(ToDoDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Project> GetAll() => _context.Projects.ToList();

        public Project Get(int id) => _context.Projects.Find(id);

        public void Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Update(int id, [FromBody] Project project)
        {
            var existingProject = _context.Projects.Find(id);
            if (existingProject is not null)
            {
                existingProject.Id = id;
                existingProject.Description = project.Description ?? existingProject.Description;
                existingProject.Name = project.Name ?? existingProject.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var project = _context.Projects.Find(id);
            if (project is not null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
    }
}