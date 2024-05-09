using Project.API.Models;

namespace Project.API.Interfaces
{
    public interface IProjectService
    {
        public Task<ResponseModel> CreateProject(ProjectDTO projectDTO);

        public Task<List<ProjectModel>> GetAllProjects();
    }
}
