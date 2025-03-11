using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackthonTask.Model;

namespace HackthonTask.Repository
{
    internal interface IPolicy
    {
        int AddPolicy(Policy policy);
        Policy FindById(int id);
        List<Policy> DisplayAllPolicies();
        List<Policy> SearchById(int id);

        void UpdateById(int id);
        void DeleteById(int id);
        //void ViewActivePolicies();
    }
}
