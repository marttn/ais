using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdCustomerVM
    {
        private RelayCommand<object> updCust;
        public Customer CurrentCustomer { get; } = StationManager.CurrentCustomer;

        public RelayCommand<object> UpdCust
        {
            get => updCust ?? (updCust = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
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

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateCustomer(StationManager.CurrentCustomer, CurrentCustomer);
            StationManager.CurrentCustomer = CurrentCustomer;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
