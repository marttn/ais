using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ais.Models
{
    class Contractor
    {

        public string codeContractor;
        public string nameContractor;
        public string city;
        public string street;
        public string building;
        public int porch;
        public int office;
        public string account;
        public string email;

        public Contractor(string codeContractor= "", string nameContractor="", string city="", string street="", string building="", int porch=0, int office=0, string account="", string email="")
        {
            CodeContractor = codeContractor;
            NameContractor = nameContractor;
            City = city;
            Street = street;
            Building = building;
            Porch = porch;
            Office = office;
            Account = account;
            Email = email;
        }

        public string CodeContractor
        {
            get => codeContractor;
            set
            {
                codeContractor = value;
                OnPropertyChanged();
            }
        }
        public string NameContractor
        {
            get => nameContractor;
            set
            {
                nameContractor = value;
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
        public string Account
        {
            get => account;
            set
            {
                account = value;
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
