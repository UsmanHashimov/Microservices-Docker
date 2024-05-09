using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Domain.Entities.Models
{
    public class EmployeeModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
    }
}
