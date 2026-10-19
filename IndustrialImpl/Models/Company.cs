using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl.Models
{
    public class Company
    {
        public required string Name { get; set; }
        public List<Department> Departments { get; set; } = new();
        public OverallCompanyFinancialMetrics OverallCompanyFinancialMetrics { get; set; } = new();
    }
}
