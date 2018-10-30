using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public virtual Department Department { get; set; }
    }
}