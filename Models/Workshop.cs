namespace ais.Models
{
    class Workshop
    {
        public Workshop(string codeWorkshop, string name, string telNum, string city, string street, string building, int porch, int office, string accountShop, double priceOneCurtain)
        {
            CodeWorkshop = codeWorkshop;
            Name = name;
            TelNum = telNum;
            City = city;
            Street = street;
            Building = building;
            Porch = porch;
            Office = office;
            AccountShop = accountShop;
            PriceOneCurtain = priceOneCurtain;
        }

        public string CodeWorkshop { get; set; }
        public string Name { get; set; }
        public string TelNum { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Building { get; set; }
        public int Porch { get; set; }
        public int Office { get; set; }
        public string AccountShop { get; set; }
        public double PriceOneCurtain { get; set; }
    }
}
