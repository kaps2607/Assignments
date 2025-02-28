using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2.Model
{
    internal class Manager:Employee
    {
        public double Bonus { get; set; }
        public Manager(string name, double sal, double bonus) : base(name, sal)
        {
            Bonus = bonus;
        }
        public override void DisplayDetails()
        {
            Console.WriteLine($"Name: {Name}\nSalary: {Salary}\nBonus: {Bonus}");
        }
    }
}
