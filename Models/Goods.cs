using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ais.Models
{
    class Goods
    {

        public string articul;
        public string name;
        public string type;
        public string material;
        public string characteristics;


        public Goods(string articul = "", string name = "", string type = "", string material = "", string characteristics = "")
        {
            Articul = articul;
            Name = name;
            Type = type;
            Material = material;
            Characteristics = characteristics;
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

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

