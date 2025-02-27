namespace Question1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter basic salary: ");
            double basicSal = Convert.ToDouble(Console.ReadLine());
            double taxDeduction = 0.1 * basicSal;
            Console.Write("Enter ratings that you have received(1-10): ");
            int ratings = Convert.ToInt32(Console.ReadLine());
            double bonus;
            if (ratings >= 8)
            {
                bonus = 0.2 * basicSal;
            }
            else if (ratings >= 5 && ratings < 8)
            {
                bonus = 0.1 * basicSal;
            }
            else
            {
                bonus = 0;
            }

            double netSalary = basicSal - taxDeduction + bonus;
            Console.WriteLine($"Your net salary is {netSalary}");

        }
    }
}
