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
    }
}