using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ais.Models
{
    class Goods
    {

        private string articul;
        private string name;
        private string type;
        private string material;
        private string characteristics;
        private double sellingPrice;


        public Goods(string articul = "", string name = "", string type = "", string material = "",
            string characteristics = "", double sellingPrice = 0.0)
        {
            Articul = articul;
            Name = name;
            Type = type;
            Material = material;
            Characteristics = characteristics;
            SellingPrice = sellingPrice;
        }

        public string Articul
        {
            get => articul;
            set
            {
                articul = value;
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
        public string Type
        {
            get => type;
            set
            {
                type = value;
                OnPropertyChanged();
            }
        }
        public string Material
        {
            get => material;
            set
            {
                material = value;
                OnPropertyChanged();
            }
        }
        public string Characteristics
        {
            get => characteristics;
            set
            {
                characteristics = value;
                OnPropertyChanged();
            }
        }
        public double SellingPrice
        {
            get => sellingPrice;
            set
            {
                sellingPrice = value;
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

