using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Text.RegularExpressions;
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
            return new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCustomer.LastName) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCustomer.Name) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCustomer.City) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCustomer.Street) &&
                   new Regex("^\\d+[a-zA-ZА-Яа-я]*$").IsMatch(CurrentCustomer.Building) && CurrentCustomer.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Apartment.ToString()) &&
                   new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(CurrentCustomer.Email);
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
