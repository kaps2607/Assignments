using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2.Model
{
    internal class Commercial : VehicleInsurance
    {
        public Commercial(string name) : base(name, "Commercial") { }

        public override double CalculatePremium()
        {
            return 15000;
        }
    }
}
