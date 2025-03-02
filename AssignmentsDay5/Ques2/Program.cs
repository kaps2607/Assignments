using Ques2.Model;

namespace Ques2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleInsurance v1= new TwoWheeler("Kapil");
            v1.DisplayDetails();
            Console.WriteLine("-------------------------");
            VehicleInsurance v2 = new FourWheeler("Kaps");
            v2.DisplayDetails();
            Console.WriteLine("-------------------------");
            VehicleInsurance v3 = new Commercial("Kaps Transport");
            v3.DisplayDetails();
            Console.WriteLine("-------------------------");
        }
    }
}
