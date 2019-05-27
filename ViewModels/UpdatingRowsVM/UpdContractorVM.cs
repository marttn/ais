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
    class UpdContractorVM
    {
        private RelayCommand<object> updateContractor;

        
        public Contractor CurrentContractor { get; } = StationManager.CurrentContractor;

        public RelayCommand<object> UpdateContractor
        {
            get => updateContractor ?? (updateContractor = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentContractor.NameContractor) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.City) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Office.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Account) && CurrentContractor.Account.Length == 16 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Email);
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateContractor(StationManager.CurrentContractor, CurrentContractor);
            StationManager.CurrentContractor = CurrentContractor;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
