using System;

namespace ais.Models
{
    class Contract
    {
        public Contract(string numContract = "", DateTime dateContract = new DateTime(), string codeContractor = "", double totalCost = 0.0)
        {
            NumContract = numContract;
            DateContract = dateContract;
            CodeContractor = codeContractor;
            TotalCost = totalCost;
        }

        public string NumContract { get; set; }
        public DateTime DateContract { get; set; }
        public string CodeContractor { get; set; }
        public double TotalCost { get; set; }

    }
}
