using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuranceApp.Exceptions;
using InsuranceApp.Model;

namespace InsuranceApp.Repositories
{
    internal class PolicyRepository : IPolicyRepository
    {
        List<Policy> policies = new List<Policy>();

        public void AddPolicy(Policy policy)
        {
            if (policies.Any(p => p.PolicyId == policy.PolicyId))
            {
                Console.WriteLine("Policy Id already exists.");
                return;
            }
            policies.Add(policy);
            Console.WriteLine("Policy added successfully!!");
        }

        public List<Policy> GetAllPolicies() => policies;

        public Policy SearchPolicy(int id)
        {
            var policy = policies.FirstOrDefault(p => p.PolicyId == id);
            if (policy == null)
            {
                throw new PolicyNotFoundException($"Policy with Id {id} not found!");
            }
            return policy;
        }

        public void UpdatePolicy(int id, string name)
        {
            var policy = SearchPolicy(id);
            policy.PolicyHolderName = name;
            Console.WriteLine("Policy Updated successfully.");
        }
        public void DeletePolicy(int id) 
        { 
            var policy=SearchPolicy(id);
            policies.Remove(policy);
            Console.WriteLine("Policy Deleted successfully");
        }
        public List<Policy> GetActivePolicies()=>policies.Where(p=>p.IsActive()).ToList();
    }
}
