using System;
using System.Collections.Generic;

namespace ABB.RCS.ProjectManagament.Models
{
    public partial class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public float? Salary { get; set; }
    }
}
