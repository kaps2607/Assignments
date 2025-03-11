using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackthonTask.Exceptions;
using HackthonTask.Model;
using HackthonTask.Uitility;
using static HackthonTask.Model.Policy;

namespace HackthonTask.Repository
{
    internal class PolicyRepo : IPolicy
    {
        //SqlConnection SqlConnection = null;
        SqlCommand cmd = null;
        string connstring;

        public PolicyRepo()
        {
            cmd = new SqlCommand();
            connstring=DbUitility.GetConnectionString();

        }

        public int AddPolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {

                cmd.CommandText = "Insert into Policys(PolicyHolderName,PolicyType,StartDate,EndDate) values (@Name,@type,@Start,@EndDate)";

                

                cmd.Parameters.AddWithValue("@name",policy.PolicyHolderName);
                cmd.Parameters.AddWithValue("@Type", policy.PolicyType.ToString());
                cmd.Parameters.AddWithValue("@Start", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);


                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();



            }
        }

        public void DeleteById(int id)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connstring))
                {
                

                cmd.CommandText = "Delete from Policys where PolicyId=@Id";
                    cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id",id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                var abc= cmd.ExecuteNonQuery();
                    
                    if (abc == 0)
                    {
                       throw new PolicyNotFoundException($"policy with Id {id} is not existed");
                    }
                    else
                    {
                        Console.WriteLine($"Policy with id {id} id delete successfully");
                    }
                    
                }
             }
            catch (PolicyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public List<Policy> DisplayAllPolicies()
        {
            List<Policy> policies = new List<Policy>();
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "select * from Policys";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Policy policy = new Policy();
                    policy.PolicyID = reader.GetInt32("PolicyID");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    
                    policy.PolicyType = Enum.Parse < PolicyTypes >(reader.GetString("PolicyType"));
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");
                    policies.Add(policy);

                }
            }
                return policies;
        }





      

        public List<Policy> SearchById(int id)
        {
            List<Policy> policyNew = new List<Policy>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connstring))
                {
                    // Fix: Change column name from 'id' to 'PolicyID'
                    cmd.CommandText = "select * from Policys where PolicyID=@id";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        throw new PolicyNotFoundException($"Policy id {id} is not exists");
                    }

                    while (reader.Read())
                    {
                        Policy policy = new Policy();
                        policy.PolicyID = reader.GetInt32("PolicyID");
                        policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                        policy.PolicyType = Enum.Parse<PolicyTypes>(reader.GetString("PolicyType"));
                        policy.StartDate = reader.GetDateTime("StartDate");
                        policy.EndDate = reader.GetDateTime("EndDate");
                        policyNew.Add(policy);
                    }
                }

                return policyNew;
            }
            catch (PolicyNotFoundException e)
            {
                Console.WriteLine(e.Message);
                // Important: Return empty list rather than null
                return new List<Policy>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Important: Return empty list rather than null
                return new List<Policy>();
            }
        }

        public Policy FindById(int id)
        {
            List<Policy> find = DisplayAllPolicies();
            return find.Find(p => p.PolicyID == id);
        }

        public void UpdateById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                try
                {
                    if (!(FindById(id) == null))
                    {

                        Console.WriteLine("Enter Updated name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Select New Policy Type: 0-Life, 1-Health, 2-Vehicle, 3-Property");
                        PolicyTypes type = Enum.Parse<PolicyTypes>(Console.ReadLine());



                        Console.WriteLine("Enter End Date(yyyy-mm-dd)");
                        DateTime edate = Convert.ToDateTime(Console.ReadLine());
                        cmd.CommandText = "Update Policys set PolicyHolderName=@Name,PolicyType=@Type,EndDate=@Edate where PolicyID=@Id";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Type", type.ToString());
                        cmd.Parameters.AddWithValue("@Edate", edate);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        var result = cmd.ExecuteNonQuery();
                        if (result == 0)
                        {
                            throw new PolicyNotFoundException($"policy with Id {id} is not existed");
                        }
                        else
                        {
                            Console.WriteLine($"Policy with id {id} Updated successfully");
                        }
                    }
                    else
                    {
                        throw new PolicyNotFoundException($"policy with Id {id} is not existed");
                    }
                }

                catch(PolicyNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }


        ////Policy p1;
        //List<Policy> ListOfPolices = new List<Policy>();
        ////{
        ////    new Policy(13554,"Pranit",PolicyTypes.Life,new DateTime(2002,04,07),new DateTime(2030,04,07)),
        ////    new Policy(13555,"Atharva",PolicyTypes.Health,new DateTime(2001,01,01),new DateTime(2020,01,01)),
        ////    new Policy(13556,"Govind",PolicyTypes.Property,new DateTime(2002,02,27),new DateTime(2030,04,07)),
        ////    new Policy(13557,"kapil",PolicyTypes.Life,new DateTime(2005,12,31),new DateTime(2010,04,07))
        ////};


        ////--------------Search Policy By Id--------

        //public List<Policy> SearchById(int id)
        //{
        //    try
        //    {
        //        if (FindById(id) != null)
        //        {
        //            List<Policy> policyNew = new List<Policy>();
        //            using (SqlConnection sqlConnection = new SqlConnection(connstring))
        //            {
        //                cmd.CommandText = "select * from Policys where id=@id";
        //                cmd.Parameters.AddWithValue("@id", id);
        //                cmd.Connection = sqlConnection;
        //                sqlConnection.Open();
        //                SqlDataReader reader = cmd.ExecuteReader();
        //                if (!reader.HasRows)
        //                {
        //                    throw new PolicyNotFoundException($"Policy id {id} is not exists");
        //                }
        //                while (reader.Read())
        //                {
        //                    Policy policy = new Policy();
        //                    policy.PolicyID = reader.GetInt32("PolicyID");
        //                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
        //                    policy.PolicyType = Enum.Parse<PolicyTypes>(reader.GetString("PolicyType"));
        //                    policy.StartDate = reader.GetDateTime("StartDate");
        //                    policy.EndDate = reader.GetDateTime("EndDate");
        //                    policyNew.Add(policy);

        //                }

        //            }
        //            return policyNew;

        //        }
        //        else
        //        {
        //            throw new PolicyNotFoundException($"Policy Id:{id} is not Found!!");
        //        }
        //    }
        //    catch (PolicyNotFoundException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }


        //}

        ////-----------------Add New Policy--------------
        //public void AddPolicy()
        //{
        //    try
        //    {

        //        Console.WriteLine("Enter Policy Id:");
        //        int pId = Convert.ToInt32(Console.ReadLine());
        //        if (FindById(pId) == null)
        //        {
        //        Name:
        //            Console.Write("Enter Policy Holder Name: ");
        //            string policyHolderName = Console.ReadLine();
        //            while (string.IsNullOrWhiteSpace(policyHolderName))
        //            {
        //                Console.Write("Policy Holder Name cannot be empty. Enter again: ");
        //                goto Name;
        //            }

        //        PolicyTypes:
        //            Console.WriteLine("Select Policy Type: 0-Life, 1-Health, 2-Vehicle, 3-Property");
        //            PolicyTypes type;
        //            while (!Enum.TryParse(Console.ReadLine(), out type) || !Enum.IsDefined(typeof(PolicyTypes), type))
        //            {
        //                Console.Write("Invalid Policy Type. Enter again: ");
        //                goto PolicyTypes;
        //            }

        //        DateTime sDate = DateTime.Now;

        //        EndDate:
        //            Console.WriteLine("Enter End date in yyyy-mm-dd");
        //            DateTime eDate;
        //            while (!DateTime.TryParse(Console.ReadLine(), out eDate))
        //            {
        //                Console.WriteLine("Invalid date format. Enter again:");
        //                goto EndDate;
        //            }

        //            ListOfPolices.Add(new Policy(pId, policyHolderName, type, sDate, eDate));
        //            Console.WriteLine("Policy added successfully!");

        //        }
        //        else
        //        {
        //            throw new IdIsAlreadyPresentException($"Policy id::{pId} is already available!!");
        //        }
        //    }
        //    catch (IdIsAlreadyPresentException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }


        //}


        //public Policy FindById(int id)
        //{
        //    return ListOfPolices.Find(p => p.PolicyID == id);
        //}

        ////----------View All Policies---------
        //public void DisplayAllPolicies()
        //{
        //    Console.WriteLine("All Policies:");
        //    foreach (var policy in ListOfPolices)
        //    {
        //        Console.WriteLine($"Policy ID: {policy.PolicyID}\tPolicy Holder: {policy.PolicyHolderName}\tType: {policy.PolicyType}\tStart Date: {policy.StartDate:yyyy-MM-dd}\tEnd Date: {policy.EndDate:yyyy-MM-dd}");
        //    }
        //}






        ////-------------Update By Id-----

        //public void UpdateById(int id)
        //{
        //    try
        //    {
        //        if (FindById(id) != null)
        //        {
        //            var policy = ListOfPolices.FirstOrDefault(p => p.PolicyID == id);


        //            Console.Write("Enter Policy Holder Name: ");
        //            string name = Console.ReadLine();

        //            if (name != "")
        //            {
        //                policy.PolicyHolderName = name;
        //            }


        //        Type:
        //            Console.WriteLine("Select New Policy Type: 0-Life, 1-Health, 2-Vehicle, 3-Property");
        //            string pType = Console.ReadLine();
        //            PolicyTypes type;

        //            if (pType !="")
        //            {
        //                if (!Enum.TryParse(pType, out type) || !Enum.IsDefined(typeof(PolicyTypes), type))
        //                {
        //                    Console.Write("Invalid Policy Type. Enter again: ");
        //                    goto Type;
        //                }
        //                policy.PolicyType = type;
        //            }

        //        EndDate:
        //            Console.Write("Enter New End Date (yyyy-MM-dd): ");
        //            string endD = Console.ReadLine();
        //            DateTime endDate;
        //            if (endD != "")
        //            {
        //                if (!DateTime.TryParse(endD, out endDate) || endDate <= policy.StartDate)
        //                {
        //                    Console.Write("Invalid End Date. Must be after Start Date. Enter again: ");
        //                    goto EndDate;
        //                }
        //                policy.EndDate = endDate;
        //            }

        //            Console.WriteLine("Policy updated successfully!");



        //        }
        //        else
        //        {
        //            throw new PolicyNotFoundException($"Policy Id:{id} is not Found!!");
        //        }
        //    }
        //    catch (PolicyNotFoundException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}


        ////------------------Delete Policy--------------

        //public void DeleteById()
        //{
        //    try
        //    {
        //        Console.Write("Enter Policy ID to delete: ");
        //        int policyID;
        //        while (!int.TryParse(Console.ReadLine(), out policyID))
        //        {
        //            Console.Write("Invalid input. Enter Policy ID again: ");
        //        }

        //        var policy = ListOfPolices.FirstOrDefault(p => p.PolicyID == policyID);
        //        if (policy != null)
        //        {
        //            Console.Write("Are you sure you want to delete this policy? (yes/no): ");
        //            string confirmation = Console.ReadLine().ToLower();
        //            if (confirmation == "yes")
        //            {
        //                ListOfPolices.Remove(policy);
        //                Console.WriteLine("Policy deleted successfully!");
        //            }
        //            else
        //            {
        //                Console.WriteLine("Policy deletion canceled.");
        //            }
        //        }
        //        else
        //        {
        //            throw new PolicyNotFoundException($"Policy Id:{policyID} is not Found!!");
        //        }
        //    }
        //    catch (PolicyNotFoundException e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}


        ////-------------------------is active---------

        //public void ViewActivePolicies()
        //{
        //    var activePolicie = ListOfPolices.Where(p => p.IsActive()).ToList();
        //    if (activePolicie.Any())
        //    {
        //        Console.WriteLine("Active Policies");
        //        foreach (var sp in activePolicie)
        //        {
        //            Console.WriteLine($"Policy Id:{sp.PolicyID}\t Policy Holder Name:{sp.PolicyHolderName}\tPolicy Type:{sp.PolicyType}\t Start Date:{sp.StartDate:yyyy-MM-dd}\tEnd Date:{sp.EndDate:yyyy-MM-dd}");
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("No Active Policy Found");
        //    }
        //}


    }
}