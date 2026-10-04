using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl.Models
{
    public class Department
    {
        public required string Name { get; set; }
        public double EmployeesShare { get; set; }
        public double IncomeShare { get; set; }
    }
}
