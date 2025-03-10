using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceAppDB.Models;

namespace InsuranceAppDB.Repositories
{
    internal interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        Policy SearchPolicy(int id);
        void UpdatePolicy(Policy policy);
        void DeletePolicy(int id);
        List<Policy> GetActivePolicies();
    }
}
