using System.Reflection.Emit;

namespace Question2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalAmt = 0; // Store total amount

            while (true) // Loop until the user chooses to exit
            {
                Console.WriteLine("\nEnter which type of ticket you want to book:");
                Console.WriteLine("1. General: ₹200/-");
                Console.WriteLine("2. AC: ₹1000/-");
                Console.WriteLine("3. Sleeper: ₹500/-");
                Console.WriteLine("4. Exit");

                Console.Write("Your choice: ");
                bool isValidChoice = int.TryParse(Console.ReadLine(), out int choice);

                if (!isValidChoice || choice < 1 || choice > 4)
                {
                    Console.WriteLine("Please enter a valid option (1-4)!");
                    continue; // go back to menu
                }

                if (choice == 4) // exit condition
                {
                    break;
                }

                Console.Write("Enter how many tickets you want to book: ");
                bool isValidTickets = int.TryParse(Console.ReadLine(), out int numOfTickets);

                if (!isValidTickets || numOfTickets <= 0)
                {
                    Console.WriteLine("Invalid ticket count! Please enter a valid number.");
                    continue; // restart menu
                }

                switch (choice)
                {
                    case 1:
                        totalAmt += 200 * numOfTickets;
                        break;
                    case 2:
                        totalAmt += 1000 * numOfTickets;
                        break;
                    case 3:
                        totalAmt += 500 * numOfTickets;
                        break;
                }
                Console.WriteLine($"{numOfTickets} ticket(s) booked successfully!");
            }

            if (totalAmt > 0) //to display final payment if tickets are booked
            {
                Console.WriteLine("\nPayment Details:");
                Console.WriteLine($"Total Amount: ₹{totalAmt}");
                Console.WriteLine("You can pay via net banking or UPI (QR code below).");
            }
            else
            {
                Console.WriteLine("\nNo tickets booked. Exiting...");
            }
        }
    }
}
