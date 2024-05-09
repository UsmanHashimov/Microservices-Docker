using Employee.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.UseCases.EmployeeCases.Commands
{
    public class CreateEmployeeCommand : IRequest<ResponceModel>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
