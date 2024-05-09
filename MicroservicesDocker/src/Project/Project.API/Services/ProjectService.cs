using Microsoft.EntityFrameworkCore;
using Project.API.Interfaces;
using Project.API.Models;
using Project.API.Persistence;

namespace Project.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectDbContext _context;

        public ProjectService(ProjectDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> CreateProject(ProjectDTO projectDTO)
        {
            var project = new ProjectModel
            {
                Name = projectDTO.Name,
                Description = projectDTO.Description,
                EndDate = projectDTO.EndDate,
                Status = projectDTO.Status
            };

            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();

            return new ResponseModel { Message = "Project created", Status = 201, isSuccess = true };
        }

        public async Task<List<ProjectModel>> GetAllProjects()
        {
            var res = await _context.Projects.ToListAsync();

            return res;
        }
    }
}
