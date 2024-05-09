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
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ResponceModel>
    {
        private readonly IEmployeeDBContext _context;

        public DeleteEmployeeCommandHandler(IEmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (res == null)
            {
                return new ResponceModel { Message = "Employee not found", StatusCode = 404 };
            }

            _context.Employees.Remove(res);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "Employee removed",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
