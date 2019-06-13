using System;

namespace ais.Models
{
    public class Order
    {
        
        public Order(string numOrd = "", DateTime dateOrd = new DateTime(), string iD = "", string codeWorkshop = "", string ipn = "",
            double costCornices = 0.0, double costCurtains = 0.0, double costGoods = 0.0, double totalCost = 0.0)
        {
            NumOrd = numOrd;
            DateOrd = dateOrd;
            ID = iD;
            CodeWorkshop = codeWorkshop;
            Ipn = ipn;
            CostCornices = costCornices;
            CostCurtains = costCurtains;
            CostGoods = costGoods;
            TotalCost = totalCost;
        }
        public string NumOrd { get; set; }
        public DateTime DateOrd { get; set; }
        public string ID { get; set; }
        public string CodeWorkshop { get; set; }
        public string Ipn { get; set; }
        public double CostCornices { get; set; }
        public double CostCurtains { get; set; }
        public double CostGoods { get; set; }
        public double TotalCost { get; set; }
    }
}
