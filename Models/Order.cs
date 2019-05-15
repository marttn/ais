using System;

namespace ais.Models
{
    class Order
    {
        public Order(string numOrd, DateTime dateOrd, string iD, string codeWorkshop, string ipn)
        {
            NumOrd = numOrd;
            DateOrd = dateOrd;
            ID = iD;
            CodeWorkshop = codeWorkshop;
            Ipn = ipn;
        }

        public string NumOrd { get; set; }
        public DateTime DateOrd { get; set; }
        public string ID { get; set; }
        public string CodeWorkshop { get; set; }
        public string Ipn { get; set; }
    }
}
