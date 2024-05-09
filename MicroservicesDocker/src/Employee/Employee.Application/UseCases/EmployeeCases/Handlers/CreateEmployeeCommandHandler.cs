using Employee.Application.Abstractions;
using Employee.Application.UseCases.EmployeeCases.Commands;
using Employee.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.UseCases.EmployeeCases.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, ResponceModel>
    {
        private readonly IEmployeeDBContext _context;

        public CreateEmployeeCommandHandler(IEmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Employees.FirstOrDefaultAsync(x => x.Email == request.Email);
            
            if (res != null)
            {
                return new ResponceModel
                {
                    Message = "This email already exists",
                    StatusCode = 409
                };
            }

            var employee = new EmployeeModel
            {
                Name = request.Name,
                Email = request.Email,
                Status = request.Status
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "Employee registered!",
                StatusCode = 201,
                IsSuccess = true
            };
        }
    }
}
