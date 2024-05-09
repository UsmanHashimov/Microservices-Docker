using Department.API.Models;

namespace Department.API.Interfaces
{
    public interface IDepartmentService
    {
        public Task<ResponseModel> CreateDepartment(DepartmentDTO model);
        public Task<List<DepartmentModel>> GetAllDepartments();
    }
}
