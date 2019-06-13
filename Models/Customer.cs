using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ais.Tools.Managers;

namespace ais.Models
{
    class Customer
    {
        private string id;
        private string lastName;
        private string name;
        private string middleName;
        private string city;
        private string street;
        private string building;
        private int porch;
        private int _apartment;
        private string email;
        private ObservableCollection<Order> _customersOrders;

        public Customer(string iD = "", string lastName = "", string name = "", string middleName = "", string city = "", string street = "", string building = "", int porch = 0, int apartment= 0, string email = "")
        {
            ID = iD;
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
            City = city;
            Street = street;
            Building = building;
            Porch = porch;
            Apartment = apartment;
            Email = email;
           // CustomersOrders = new ObservableCollection<Order>(StationManager.DataStorage.CustomersOrdersList(iD));
        }

        public string ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
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
        public int Apartment
        {
            get => _apartment;
            set
            {
                _apartment = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order> CustomersOrders
        {
            get
            {
                if (_customersOrders == null)
                {
                    GetList();
                }
                return _customersOrders;
            }
        }

        private void GetList()
        {
            try
            {
                _customersOrders = new ObservableCollection<Order>(StationManager.DataStorage.CustomersOrdersList(ID));
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message + "\n" + exc.Source + "\n" + exc.StackTrace);
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
