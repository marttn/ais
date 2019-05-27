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
    class UpdWorkshopVM
    {
        private RelayCommand<object> updateWorkshop;
        public Workshop CurrentWorkshop { get; } = StationManager.CurrentWorkshop;
        
        public RelayCommand<object> UpdateWorkshop
        {
            get => updateWorkshop ?? (updateWorkshop = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentWorkshop.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.TelNum) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.City) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Office.ToString()) && CurrentWorkshop.Office != 0 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.AccountShop) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.PriceOneCurtain.ToString()) && CurrentWorkshop.PriceOneCurtain != 0;
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateWorkshop(StationManager.CurrentWorkshop, CurrentWorkshop);
            StationManager.CurrentWorkshop = CurrentWorkshop;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
