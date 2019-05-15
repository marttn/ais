using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Contractor_Tel
    {
        public Contractor_Tel(string telNum, string codeContractor)
        {
            TelNum = telNum;
            CodeContractor = codeContractor;
        }

        public string TelNum { get; set; }
        public string CodeContractor { get; set; }
    }
}
