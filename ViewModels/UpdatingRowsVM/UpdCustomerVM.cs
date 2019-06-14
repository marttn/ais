using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Text.RegularExpressions;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdCustomerVM
    {
        private RelayCommand<Window> _updCust;
        public Customer CurrentCustomer { get; } = StationManager.CurrentCustomer;

        public RelayCommand<Window> UpdCust
        {
            get => _updCust ?? (_updCust = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
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

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateCustomer(StationManager.CurrentCustomer, CurrentCustomer);
            StationManager.CurrentCustomer = CurrentCustomer;
            obj.Close(); 
        }
    }
}
