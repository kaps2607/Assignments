namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> bankQueue = new Queue<string>();
            bankQueue.Enqueue("Customer 1");
            bankQueue.Enqueue("Customer 2");
            bankQueue.Enqueue("Customer 3");

            Console.WriteLine("Customers in Queue:");
            foreach (var customer in bankQueue)
            {
                Console.WriteLine(customer);
            }

            //check who is next in line without removing them
            //bankQueue.Peek();
            //Console.WriteLine(bankQueue.Peek());
            if (bankQueue.Count > 0)
            {
                Console.WriteLine("Next customer to be served is: " + bankQueue.Peek());
            }
            while (bankQueue.Count > 0) 
            { 
                string servedCustomer=bankQueue.Dequeue();
                Console.WriteLine("Serving: "+servedCustomer);
            }
            Console.WriteLine("All customers have been served");
        }
    }
}
