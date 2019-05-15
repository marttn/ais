namespace ais.Models
{
    class Order_Goods
    {
        public Order_Goods(string numOrd, string articul, int quantityGoods)
        {
            NumOrd = numOrd;
            Articul = articul;
            QuantityGoods = quantityGoods;
        }

        public string NumOrd { get; set; }
        public string Articul { get; set; }
        public int QuantityGoods { get; set; }
    }
}
