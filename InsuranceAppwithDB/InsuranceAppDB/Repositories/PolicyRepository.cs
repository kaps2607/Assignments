using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceAppDB.Exceptions;
using InsuranceAppDB.Models;
using InsuranceAppDB.Utility;

namespace InsuranceAppDB.Repositories
{
    internal class PolicyRepository : IPolicyRepository
    {
        List<Policy> policies = new List<Policy>();

        SqlCommand cmd = null;
        string connstring;

        public PolicyRepository()
        {
            //sqlConnection = new SqlConnection("Server=DESKTOP-0TE71RT;Database=BikeStore;Trusted_Connection=True");
            //comment the below line to execute stored procedures
            cmd = new SqlCommand();
            connstring = DbConnUtil.GetConnectionString();
        }

        public int AddPolicy(Policy policy)
        {
            //if (policies.Any(p => p.PolicyId == policy.PolicyId))
            //{
            //    Console.WriteLine("Policy Id already exists.");
            //    return;
            //}
            //policies.Add(policy);
            //Console.WriteLine("\nPolicy added successfully!!");
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                //cmd.Parameters.Clear();
                cmd.CommandText = "Insert into Policies values(@PolicyHolderName, @Type, @StartDate, @EndDate)";
                cmd.Parameters.AddWithValue("@PolicyHolderName", policy.PolicyHolderName);
                cmd.Parameters.AddWithValue("@Type", policy.Type);
                cmd.Parameters.AddWithValue("@StartDate", policy.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", policy.EndDate);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
                //return cmd.ExecuteScalar(); //check this method
            }
        }

        public List<Policy> GetAllPolicies()
        {
            List<Policy> policies=new List<Policy>();
            using(SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                cmd.CommandText = "select * from Polucues";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    //create an object of PolicyClass
                    Policy policy = new Policy();
                    policy.PolicyId = reader.GetInt32("PolicyId");
                    policy.PolicyHolderName = reader.GetString("PolicyHolderName");
                    policy.Type = reader.GetString("Type");
                    policy.StartDate = reader.GetDateTime("StartDate");
                    policy.EndDate = reader.GetDateTime("EndDate");
                    policies.Add(policy);
                }
            }
            return policies;
        }

        public Policy SearchPolicy(int id)
        {
            var policy = policies.FirstOrDefault(p => p.PolicyId == id);
            if (policy == null)
            {
                throw new PolicyNotFoundException($"Policy with Id {id} not found!");
            }
            return policy;
        }

        //public void UpdatePolicy(int id, string name)
        //{
        //    var policy = SearchPolicy(id);
        //    policy.PolicyHolderName = name;
        //    Console.WriteLine("Policy Updated successfully.");
        //}

        public int UpdatePolicy(Policy policy)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connstring))
            {
                Console.WriteLine();
            }
            //if (!(policies.Any(p => p.PolicyId == policy.PolicyId)))
            //{
            //    Console.WriteLine("Policy Id does not exist.");
            //    return;
            //}
            //policies.Add(policy);
            //Console.WriteLine("\nPolicy updated successfully!!");
        }
        public int DeletePolicy(int id)
        {
            using(SqlConnection sqlConnection=new SqlConnection(connstring))
            {
                cmd.CommandText = "Delete from Policies where PolicyId=@PolicyId";
                cmd.Parameters.AddWithValue("@PolicyId", id);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                return cmd.ExecuteNonQuery();
            }
            //var policy = SearchPolicy(id);
            //policies.Remove(policy);
            //Console.WriteLine("Policy Deleted successfully");
        }
        public List<Policy> GetActivePolicies() => policies.Where(p => p.IsActive()).ToList();
    }
}
