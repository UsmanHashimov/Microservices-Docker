using Employee.Application.Abstractions;
using Employee.Application.UseCases.EmployeeCases.Queries;
using Employee.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.UseCases.EmployeeCases.Handlers.QueryHandlers
{
    public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<EmployeeModel>>
    {
        private readonly IEmployeeDBContext _context;

        public GetAllEmployeeQueryHandler(IEmployeeDBContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeModel>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);

            return employees;
        }
    }
}
