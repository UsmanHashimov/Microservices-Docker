using Employee.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.UseCases.EmployeeCases.Commands
{
    public class DeleteEmployeeCommand : IRequest<ResponceModel>
    {
        public Guid Id { get; set; }
    }
}
