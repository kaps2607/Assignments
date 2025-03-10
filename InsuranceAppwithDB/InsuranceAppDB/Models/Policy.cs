using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceAppDB.Models
{
    public enum PolicyType
    { Life, Health, Vehicle, Property }
    internal class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy(int id, string name, PolicyType type, DateTime start, DateTime end)
        {
            PolicyId = id;
            PolicyHolderName = name;
            Type = type;
            StartDate = start;
            EndDate = end;
        }

        public bool IsActive()
        {
            return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        }

        public override string ToString()
        {
            return $"Id: {PolicyId}\nHolder: {PolicyHolderName}\nType: {Type}\nStarted on: {StartDate.ToShortDateString()}\nEnd: {EndDate.ToShortDateString()}\nActive: {IsActive()}";
        }
    }
}
