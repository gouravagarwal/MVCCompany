using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDemo.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string DeptName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
