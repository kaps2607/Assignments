using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HackthonTask.Model
{

    internal class Policy
    {
    //public enum PolicyTypes
    //{
    //    Life,
    //    Health,
    //    Vehicle,
    //    Property
    //}
        

        public int PolicyID { get; set; }
        public string PolicyHolderName { get; set; }
        public PolicyTypes PolicyType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Policy(int id,string name,PolicyTypes type, DateTime startDate, DateTime endDate)
        {
            PolicyID = id;
            PolicyHolderName = name;
            PolicyType= type;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Policy(string name, PolicyTypes type, DateTime startDate, DateTime endDate)
        {
            
            PolicyHolderName = name;
            PolicyType = type;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Policy()
        {
            
        }
        public override string ToString()
        {
            return $"policy Id::{PolicyID}\tPolicy Holder Name::{PolicyHolderName}\tPolicy Type::{PolicyType}\tStart Date::{StartDate}\tEnd Date::{EndDate}";

        }
        public bool IsActive()
        {
            return DateTime.Now >= StartDate && DateTime.Now <= EndDate;
        }
    }
}
