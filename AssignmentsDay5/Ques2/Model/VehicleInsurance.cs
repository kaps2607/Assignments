using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques2.Model
{
    abstract class VehicleInsurance
    {
        public string PolicyHolderName {  get; set; }
        public string VehicleType { get; set; }

        public VehicleInsurance(string name, string vehicleType) 
        { 
            PolicyHolderName = name;
            VehicleType = vehicleType;
        }

        public abstract double CalculatePremium();

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Policy Holder: {PolicyHolderName}");
            Console.WriteLine($"Vehicle Type: {VehicleType}");
            Console.WriteLine($"Premium Amount: {CalculatePremium()}");
        }
    }
}
