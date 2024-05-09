using Employee.Application.UseCases.EmployeeCases.Commands;
using Employee.Application.UseCases.EmployeeCases.Queries;
using Employee.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ResponceModel> CreateEmployee(CreateEmployeeCommand command)
        {
            var res = await _mediator.Send(command);

            return res;
        }

        [HttpGet]
        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            var res = await _mediator.Send(new GetAllEmployeeQuery());

            return res;
        }

        [HttpPut]
        public async Task<ResponceModel> UpdateEmployee(UpdateEmployeeCommand command)
        {
            var res = await _mediator.Send(command);

            return res;
        }

        [HttpDelete]
        public async Task<ResponceModel> DeleteEmployee(DeleteEmployeeCommand command)
        {
            var res = await _mediator.Send(command);

            return res;
        }
    }
}
