using System;

namespace ais.Models
{
    class Contract
    {
        public Contract(string numContract, DateTime dateContract, string codeContractor)
        {
            NumContract = numContract;
            DateContract = dateContract;
            CodeContractor = codeContractor;
        }

        public string NumContract { get; set; }
        public DateTime DateContract { get; set; }
        public string CodeContractor { get; set; }

    }
}
