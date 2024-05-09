using Department.API.Interfaces;
using Department.API.Models;
using Department.API.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Department.API.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentDbContext _context;

        public DepartmentService(DepartmentDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel> CreateDepartment(DepartmentDTO model)
        {
            var department = new DepartmentModel
            {
                Name = model.Name,
                Location = model.Location
            };

            var res = await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync();

            return new ResponseModel { Message = "Department created", StatusCode = 201, isSuccess = true };
        }

        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            var departments = await _context.Departments.ToListAsync();

            return departments;
        }
    }
}
