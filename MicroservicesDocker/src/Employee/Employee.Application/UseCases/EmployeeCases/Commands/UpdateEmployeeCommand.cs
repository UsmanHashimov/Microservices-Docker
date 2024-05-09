using Employee.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.UseCases.EmployeeCases.Commands
{
    public class UpdateEmployeeCommand : IRequest<ResponceModel>
    {
        public string currentEmail { get; set; }
        public string newName { get; set; }
        public string newEmail { get; set; }
        public string newStatus { get; set; }
    }
}
