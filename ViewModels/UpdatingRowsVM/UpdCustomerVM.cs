using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return !string.IsNullOrWhiteSpace(CurrentCustomer.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.City) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Building) && CurrentCustomer.Building.Length <=4 &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Apartment.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentCustomer.Email);
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateCustomer(StationManager.CurrentCustomer, CurrentCustomer);
            StationManager.CurrentCustomer = CurrentCustomer;
            obj.Close(); 
        }
    }
}
