using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses.PersonClasses
{
    public class Supervisor : PersonClass
    {
        public List<Employee> Employees { get; set; }
    }
}
