using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Windows;
using ais.Views.AddingRows;

namespace ais.ViewModels.AddingRowsVM
{
    class CustomerViewModel
    {
        private RelayCommand<Window> _addCust;

        public Customer CurrentCustomer { get; set; }

        public CustomerViewModel()
        {
            CurrentCustomer = new Customer();
            StationManager.CurrentCustomer = CurrentCustomer;
        }

        public RelayCommand<Window> AddCust => _addCust ?? (_addCust = new RelayCommand<Window>(AddCustomerImplementation, CanAdd));

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCustomer.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.City) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Building) && CurrentCustomer.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Apartment.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Email);
        }

        private void AddCustomerImplementation(Window obj)
        {
            StationManager.DataStorage.AddCustomer(StationManager.CurrentCustomer);
            
            obj.Close();
            CustTelView tel = new CustTelView();
            tel.ShowDialog();
        }
        
    }
}
