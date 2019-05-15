using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class CustomerViewModel
    {
        private RelayCommand<object> addCust;

        public Customer CurrentCustomer { get; set; }

        public CustomerViewModel()
        {
            CurrentCustomer = new Customer("", "", "", "", "", "", "", 0, 0, "");
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
            ///*StationManager.*/CurrentCustomer = new Customer("", "", "", "", "", "", "", 0, 0, "");
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }
    }
}
