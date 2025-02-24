namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Assignment 1 & 2
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your age: ");
            //int age;
            bool isNumber = int.TryParse(Console.ReadLine(), out int age);
            if (!isNumber)
            {
                Console.WriteLine("Invalid input! Please enter a number");
            }
            Console.Write("Enter your Percentage: ");
            isNumber = double.TryParse(Console.ReadLine(), out double per);
            if (!isNumber)
            {
                Console.WriteLine("Invalid input! Please enter valid percentage also without '%'");
            }

            Console.WriteLine($"Your name: {name}\nYour age: {age}\nYour Percentage: {per}");
            #endregion
            #region Assignment 3
            Console.Write("Enter your email: ");
            string email=Console.ReadLine();
            //Console.WriteLine(email);
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("You didn't enter anything! Please enter your emailId.");
            }
            else
            {
                Console.WriteLine($"Welcome, {email}");
            }
            #endregion

        }
    }
}
