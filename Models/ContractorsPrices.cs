namespace ais.Models
{
    internal class ContractorsPrices
    {
        public ContractorsPrices(string code = "", string name = "", double price = 0.0)
        {
            Code = code;
            Name = name;
            Price = price;
        }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
