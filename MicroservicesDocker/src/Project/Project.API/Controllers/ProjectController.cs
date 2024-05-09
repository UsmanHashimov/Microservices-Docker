using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.API.Interfaces;
using Project.API.Models;

namespace Project.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateProject(ProjectDTO projectDTO)
        {
            var res = await _service.CreateProject(projectDTO);

            return res;
        }

        [HttpGet]
        public async Task<List<ProjectModel>> GetAllProjects()
        {
            var res = await _service.GetAllProjects();

            return res;
        }
    }
}
