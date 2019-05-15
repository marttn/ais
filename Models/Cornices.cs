using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Cornices
    {
        private string ipn;
        private string lastName;
        private string name;
        private string middleName;
        private string city;
        private string street;
        private string building;
        private int porch;
        private int appartment;
        private string accountCornice;
        private string telNum;
        private double priceOneCornice;


        public Cornices(string ipn, string lastName, string name, string middleName, string city, string street, string building, int porch, int appartment, string accountCornice, string telNum, double priceOneCornice)
        {
            Ipn = ipn;
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
            City = city;
            Street = street;
            Building = building;
            Porch = porch;
            Appartment = appartment;
            AccountCornice = accountCornice;
            TelNum = telNum;
            PriceOneCornice = priceOneCornice;
        }

        public string Ipn
        {
            get => ipn;
            set
            {
                ipn = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
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
        public string MiddleName
        {
            get => middleName;
            set
            {
                middleName = value;
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
        public int Appartment
        {
            get => appartment;
            set
            {
                appartment = value;
                OnPropertyChanged();
            }
        }
        public string AccountCornice
        {
            get => accountCornice;
            set
            {
                accountCornice = value;
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
        public double PriceOneCornice
        {
            get => priceOneCornice;
            set
            {
                priceOneCornice = value;
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
