using HackthonTask.Exceptions;
using HackthonTask.Model;
using HackthonTask.Repository;

namespace HackthonTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicy policy = new PolicyRepo();
            Console.WriteLine("Welcome to  menu-driven console application");
            Console.WriteLine("Press 1 for Add Policy\nPress 2 for View All Policies\nPress 3 for Search Policy by ID\nPress 4 for Update Policy Details\nPress 5 for Delete a Policy\nPress 6 for View Active Policies\n Press 7 For Exit!");
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice < 7)
            {
                switch (choice)
                {
                    case 1:
                        try
                        {
                        Name:
                            Console.Write("Enter Policy Holder Name: ");
                            string policyHolderName = Console.ReadLine();
                            while (string.IsNullOrWhiteSpace(policyHolderName))
                            {
                                Console.Write("Policy Holder Name cannot be empty. Enter again: ");
                                goto Name;
                            }

                        PolicyTypes:
                            Console.WriteLine("Select Policy Type: 0-Life, 1-Health, 2-Vehicle, 3-Property");
                            PolicyTypes type;
                            while (!Enum.TryParse(Console.ReadLine(), out type) || !Enum.IsDefined(typeof(PolicyTypes), type))
                            {
                                Console.Write("Invalid Policy Type. Enter again: ");
                                goto PolicyTypes;
                            }

                            
                            DateTime sDate = DateTime.Now;
                               EndDate:
                          Console.WriteLine("Enter End date in yyyy-mm-dd");
                            DateTime eDate;
                            while (!DateTime.TryParse(Console.ReadLine(), out eDate))
                            {
                                Console.WriteLine("Invalid date format. Enter again:");
                                goto EndDate;
                            }
                        Policy add = new Policy(policyHolderName, type, sDate, eDate);
                            policy.AddPolicy(add);
                            Console.WriteLine("Policy added successfully!");

                }
                        catch (Exception e)
                        {
                    Console.WriteLine(e.Message);
                }

                break;
                    case 2:
                    List<Policy> AllPolicies = policy.DisplayAllPolicies();
                    foreach (var item in AllPolicies)
                    {
                        Console.WriteLine(item);
                    }

                    break;
                case 3:
                    Console.WriteLine("Enter Policy Id For Search:");
                    int id = Convert.ToInt32(Console.ReadLine());
                        policy.SearchById(id);
                        break;
                case 4:
                    Console.WriteLine("Enter Policy Id:");
                    int uId = Convert.ToInt32(Console.ReadLine());
                        List<Policy> Search=policy.DisplayAllPolicies();
                        //Search.Find();
                    policy.UpdateById(uId);
                        break;
                case 5:
                        Console.WriteLine("Enter id for delete:");
                        int pID=Convert.ToInt32(Console.ReadLine());
                        policy.DeleteById(pID);

                        
                    break;
                case 6:
                    //policy.ViewActivePolicies();
                    break;
                default:
                    Console.WriteLine("Invalid Choice!!!");
                    break;




                }
                Console.WriteLine();
                Console.WriteLine("Welcome to  menu-driven console application");
                Console.WriteLine("Press 1 for Add Policy\nPress 2 for View All Policies\nPress 3 for Search Policy by ID\nPress 4 for Update Policy Details\nPress 5 for Delete a Policy\nPress 6 for View Active Policies\n Press 7 For Exit!");
                Console.WriteLine("Enter Your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
