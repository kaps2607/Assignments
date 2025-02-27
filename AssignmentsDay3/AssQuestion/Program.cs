using System.Reflection.Emit;
using AssQuestion.Model;

namespace AssQuestion
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //Car obj = new Car();
        //obj.getDetails();
        //obj.showDetails();

        //Q2 obj = new Q2(1, "Toyota", "Fortuner", 2017, 5000000);
        //obj.DisplayInfo();

        //q3
        labelpw:
            Console.Write("Enter password: ");
            string pw = Console.ReadLine();
            if (pw != null)
            {
                if (pw.Length < 6)
                {
                    Console.WriteLine("Password must be at least 6 characters long.");
                    goto labelpw;
                }
                if (!pw.Any(char.IsUpper))
                {
                    Console.WriteLine("Password must contain at least one uppercase");
                    goto labelpw;
                }
                if (!pw.Any(char.IsDigit))
                {
                    Console.WriteLine("Password must contain at least one digit");
                    goto labelpw;
                }
                else
                {
                    Console.WriteLine("You are logged in successfully, Welcome to our page :)");
                }
            }
        }
    }
}
