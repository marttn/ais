using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Cust_Tel
    {
        public Cust_Tel(string telNum, string iD)
        {
            TelNum = telNum;
            ID = iD;
        }

        public string TelNum { get; set; }
        public string ID { get; set; }
    }
}
