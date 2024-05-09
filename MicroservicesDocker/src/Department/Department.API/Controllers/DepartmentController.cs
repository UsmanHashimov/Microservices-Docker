using Department.API.Interfaces;
using Department.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Department.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ResponseModel> CreateDepartment(DepartmentDTO model)
        {
            var res = await _service.CreateDepartment(model);

            return res;
        }

        [HttpGet]
        public async Task<List<DepartmentModel>> GetAllDepartments()
        {
            var res = await _service.GetAllDepartments();

            return res;
        }
    }
}
