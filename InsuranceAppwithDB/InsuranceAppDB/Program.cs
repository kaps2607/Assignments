using InsuranceAppDB.Models;
using InsuranceAppDB.Repositories;

namespace InsuranceAppDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PolicyRepository repo = new PolicyRepository();

            while (true)
            {
                Console.WriteLine("\n===Insurance Policy Menu===");
                Console.WriteLine("1. Add Policy");
                Console.WriteLine("2. View all Policies");
                Console.WriteLine("3. Search Policy by Id");
                Console.WriteLine("4. Update Policy");
                Console.WriteLine("5. Delete Policy");
                Console.WriteLine("6. View active Policies");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Policy Id: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Policy Holder name: ");
                            string name = Console.ReadLine();
                            Console.Write("Policy type(Life/Health/Vehicle/Property): ");
                            PolicyType type = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                            Console.Write("Start Date(yyyy-mm-dd): ");
                            DateTime start = DateTime.Parse(Console.ReadLine());
                            Console.Write("End Date(yyyy-mm-dd): ");
                            DateTime end = DateTime.Parse(Console.ReadLine());

                            repo.AddPolicy(new Policy(id, name, type, start, end));
                            break;

                        case 2:
                            foreach (var p in repo.GetAllPolicies())
                            {
                                Console.WriteLine(p);
                            }
                            break;

                        case 3:
                            Console.Write("Enter Policy Id: ");
                            int searchId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(repo.SearchPolicy(searchId));
                            break;

                        case 4:
                            Console.Write("Enter Policy Id: ");
                            int updateId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Enter new Holder name: ");
                            string newName = Console.ReadLine();
                            PolicyType newType = (PolicyType)Enum.Parse(typeof(PolicyType), Console.ReadLine(), true);
                            Console.Write("Start Date(yyyy-mm-dd): ");
                            DateTime newStart = DateTime.Parse(Console.ReadLine());
                            Console.Write("End Date(yyyy-mm-dd): ");
                            DateTime newEnd = DateTime.Parse(Console.ReadLine());
                            repo.UpdatePolicy(new Policy(updateId, newName, newType, newStart, newEnd));
                            break;

                        case 5:
                            Console.WriteLine("Enter Policy Id: ");
                            int deleteId = Convert.ToInt32(Console.ReadLine());
                            repo.DeletePolicy(deleteId);
                            break;

                        case 6:
                            foreach (var active in repo.GetAllPolicies())
                            {
                                Console.WriteLine(active);
                            }
                            break;

                        case 7:
                            return;

                        default:
                            Console.WriteLine("Invalid Option!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
