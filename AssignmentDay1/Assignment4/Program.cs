namespace Assignment4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string pname=Console.ReadLine();
            Console.Write("Enter admitting date(dd/MM/yyyy): ");
            string date=Console.ReadLine();

            bool isValid = DateTime.TryParse(date, out DateTime admitDate);
            if (!isValid)
            {
                Console.WriteLine("Invalid date format! Please enter a valid date.");
            }

            Console.Write($"Enter discharged date if Mr./Ms. Patient is discharged(dd/MM/yyyy): ");
            isValid = DateTime.TryParse(Console.ReadLine(), out DateTime disDate);
            if (!isValid)
            {
                Console.WriteLine("Invalid date format! Please enter a valid date.");
            }
            else
            {

            }
            Console.WriteLine(disDate);

            

        }
    }
}
