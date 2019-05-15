using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        private int appartment;
        private string email;

        public Customer(string iD, string lastName, string name, string middleName, string city, string street, string building, int porch, int appartment, string email)
        {
            ID = iD;
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
            City = city;
            Street = street;
            Building = building;
            Porch = porch;
            Appartment = appartment;
            Email = email;
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
        public int Appartment
        {
            get => appartment;
            set
            {
                appartment = value;
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

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
