using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2.Model
{
    internal class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(string name, double sal)
        {
            Name = name;
            Salary = sal;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Employee's Name is: {Name} and\nSalary is: {Salary}");
        }
    }
}
