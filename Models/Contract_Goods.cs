

namespace ais.Models
{
    class Contract_Goods
    {
        public Contract_Goods(string numContract, string articul, int quantity)
        {
            NumContract = numContract;
            Articul = articul;
            Quantity = quantity;
        }

        public string NumContract { get; set; }
        public string Articul { get; set; }
        public int Quantity { get; set; }
    }
}
