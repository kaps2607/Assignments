using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceDB.Models
{
    public enum PolicyType { Life, Health, Vehicle, Property}
    internal class Policy
    {
        public int PolicyId { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyType PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return $"Id: {PolicyId}, Name: {PolicyHolderName}, Type: {PolicyType}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}";
        }
    }
}
