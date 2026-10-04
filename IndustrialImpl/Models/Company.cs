using System;
using System.Collections.Generic;
using System.Text;

namespace IndustrialImpl.Models
{
    public class Company
    {
        //public Company(string name) {
        //    Name = name;
        //}
        public required string Name { get; set; }
        public List<Department> Departments { get; set; } = new();
    }
}
