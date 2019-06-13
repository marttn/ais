

namespace ais.Models
{
    class Contract_Goods
    {
        public Contract_Goods(string numContract = "", string articul ="", int quantity =0, double price = 0.0)
        {
            NumContract = numContract;
            Articul = articul;
            Quantity = quantity;
            Price = price;
        }

        public string NumContract { get; set; }
        public string Articul { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
