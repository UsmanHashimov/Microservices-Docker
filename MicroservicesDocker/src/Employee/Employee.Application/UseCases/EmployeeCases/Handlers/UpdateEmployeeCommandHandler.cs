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
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ResponceModel>
    {
        private readonly IEmployeeDBContext _context;

        public UpdateEmployeeCommandHandler(IEmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<ResponceModel> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var res = await _context.Employees.FirstOrDefaultAsync(x => x.Email == request.currentEmail);

            if (res == null)
            {
                return new ResponceModel
                {
                    Message = "Email not found",
                    StatusCode = 404
                };
            }

            var res2 = await _context.Employees.FirstOrDefaultAsync(x => x.Email == request.newEmail);

            if (res2 != null)
            {
                return new ResponceModel
                {
                    Message = "This email already exists",
                    StatusCode = 409
                };
            }

            res.Name = request.newName;
            res.Email = request.newEmail;
            res.Status = request.newStatus;

            _context.Employees.Update(res);
            await _context.SaveChangesAsync(cancellationToken);

            return new ResponceModel
            {
                Message = "Employee updated",
                StatusCode = 200,
                IsSuccess = true
            };
        }
    }
}
