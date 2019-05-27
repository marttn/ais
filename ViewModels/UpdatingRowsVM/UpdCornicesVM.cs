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
    class UpdCornicesVM
    {

        private RelayCommand<object> updateCornices;
        public Cornices CurrentCornices { get; } = StationManager.CurrentCornices;

        public RelayCommand<object> UpdateCornices
        {
            get => updateCornices ?? (updateCornices = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCornices.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.AccountCornice) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.TelNum) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.PriceOneCornice.ToString()) && CurrentCornices.PriceOneCornice != 0;
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateCornices(StationManager.CurrentCornices, CurrentCornices);
            StationManager.CurrentCornices = CurrentCornices;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
