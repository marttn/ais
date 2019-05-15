using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Contractor_Goods
    {
        public Contractor_Goods(string articul, string codeContractor, double priceOneProduct)
        {
            Articul = articul;
            CodeContractor = codeContractor;
            PriceOneProduct = priceOneProduct;
        }

        public string Articul { get; set; }
        public string CodeContractor { get; set; }
        public double PriceOneProduct { get; set; }
    }
}
