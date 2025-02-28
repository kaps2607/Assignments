using Ques2.Model;

namespace Ques2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emobj = new Employee("Kapil", 35000);
            Console.WriteLine("Before Bonus: ");
            emobj.DisplayDetails();

            Manager mobj = new Manager("Sumit", 32000, 3000);
            Console.WriteLine("After Bonus");
            mobj.DisplayDetails();
        }
    }
}
