using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class CustomerViewModel
    {
        private RelayCommand<object> addCust;
        private RelayCommand<object> addTel;

        public Customer CurrentCustomer { get; }

        public CustomerViewModel()
        {
            CurrentCustomer = new Customer();
            StationManager.CurrentCustomer = CurrentCustomer;
        }

        public RelayCommand<object> AddCust
        {
            get => addCust ?? (addCust = new RelayCommand<object>(AddCustomerImplementation, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCustomer.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.City) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Appartment.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Email);
        }

        private void AddCustomerImplementation(object obj)
        {
            StationManager.DataStorage.AddCustomer(StationManager.CurrentCustomer);
            MessageBox.Show("row added");
            NavigationManager.Instance.Navigate(ViewType.NewCustTel);
        }

        public RelayCommand<object> AddTel
        {
            get => addTel ?? (addTel = new RelayCommand<object>(AddCustTel, CanAddTel));
        }

        private bool CanAddTel(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCustomer.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Name);
        }

        private void AddCustTel(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.NewCustTel);
            //StationManager.DataStorage.AddCustTel
        }
    }
}
