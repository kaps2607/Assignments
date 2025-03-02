using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2.Model
{
    class TwoWheeler : VehicleInsurance
    {
        public TwoWheeler(string name) : base(name,"Two-Wheeler") { }

        public override double CalculatePremium()
        {
            return 3000;
        }
    }
}
