namespace Ques1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<long> beneficiaries = new List<long>{101,102};
            beneficiaries.Add(103);
            beneficiaries.Add(104);
            try
            {
                Console.Write("Enter the beneficiary Account number: ");
                long AccNum = Convert.ToInt64(Console.ReadLine());
                if (!beneficiaries.Contains(AccNum))
                {
                    throw new Exception("Beneficiary Account Number does not exist!");
                }
                Console.WriteLine("Benefciary Account Number is Valid!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter only numbers.");
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction Process Completed.");
            }
        }
    }
}
