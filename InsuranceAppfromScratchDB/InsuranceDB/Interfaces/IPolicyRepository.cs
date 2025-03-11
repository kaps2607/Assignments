using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceDB.Models;

namespace InsuranceDB.Interfaces
{
    internal interface IPolicyRepository
    {
        void AddPolicy(Policy policy);
        List<Policy> GetAllPolicies();
        Policy GetPolicyById(int id);
        void UpdatePolicy(int id,  Policy updatedPolicy);
        void DeletePolicy(int id);
        List<Policy> GetActivePolicies();
    }
}
