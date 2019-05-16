using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ais.Models
{
    class Workshop
    {

        public string codeWorkshop;
        public string name;
        public string telNum;
        public string city;
        public string street;
        public string building;
        public int porch;
        public int office;
        public string accountShop;
        public double priceOneCurtain;

        public Workshop(string codeWorkshop ="", string name = "", string telNum = "", string city = "", string street = "", string building = "", int porch = 0, int office = 0, string accountShop = "", double priceOneCurtain = 0)
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

        public string CodeWorkshop
        {
            get => codeWorkshop;
            set
            {
                codeWorkshop = value;
                OnPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string TelNum
        {
            get => telNum;
            set
            {
                telNum = value;
                OnPropertyChanged();
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public string Street
        {
            get => street;
            set
            {
                street = value;
                OnPropertyChanged();
            }
        }
        public string Building
        {
            get => building;
            set
            {
                building = value;
                OnPropertyChanged();
            }
        }
        public int Porch
        {
            get => porch;
            set
            {
                porch = value;
                OnPropertyChanged();
            }
        }
        public int Office
        {
            get => office;
            set
            {
                office = value;
                OnPropertyChanged();
            }
        }
        public string AccountShop
        {
            get => accountShop;
            set
            {
                accountShop = value;
                OnPropertyChanged();
            }
        }
        public double PriceOneCurtain
        {
            get => priceOneCurtain;
            set
            {
                priceOneCurtain = value;
                OnPropertyChanged();
            }
        }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
