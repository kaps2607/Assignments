using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2.Model
{
    class FourWheeler : VehicleInsurance
    {
        public FourWheeler(string name) : base(name, "Four-Wheeler") { }
        public override double CalculatePremium()
        {
            return 8000;
        }
    }
}
