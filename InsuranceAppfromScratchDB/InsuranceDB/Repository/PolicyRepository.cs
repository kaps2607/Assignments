using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDB.Interfaces;
using InsuranceDB.Models;
using InsuranceDB.Utility;

namespace InsuranceDB.Repository
{
    internal class PolicyRepository : IPolicyRepository
    {
        SqlCommand cmd;
        string connString;
        public PolicyRepository()
        {
             cmd = new SqlCommand();
            connString = DbConnection.GetConnectionString();

        }
        public void AddPolicy(Policy policy)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                
                
                cmd.CommandText = "insert into Policies(PolicyHolderName, PolicyType, StartDate, EndDate)values(@Name, @Type, @Start, @End)";
                cmd.Connection= conn;

                    cmd.Parameters.AddWithValue("@Name", policy.PolicyHolderName);
                    cmd.Parameters.AddWithValue("@Type", policy.PolicyType.ToString());
                    cmd.Parameters.AddWithValue("@Start", policy.StartDate);
                    cmd.Parameters.AddWithValue("@End", policy.EndDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                
            }
        }
    }
}
