using System.Globalization;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using ais.Tools.Navigation;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdWorkshopVM
    {
        private RelayCommand<Window> updateWorkshop;
        public Workshop CurrentWorkshop { get; } = StationManager.CurrentWorkshop;
        
        public RelayCommand<Window> UpdateWorkshop
        {
            get => updateWorkshop ?? (updateWorkshop = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentWorkshop.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.TelNum) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.City) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Building) && CurrentWorkshop.Building.Length <=4 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Office.ToString()) && CurrentWorkshop.Office != 0 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.AccountShop) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.PriceOneCurtain.ToString(CultureInfo.InvariantCulture)) && CurrentWorkshop.PriceOneCurtain > 0;
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateWorkshop(StationManager.CurrentWorkshop, CurrentWorkshop);
            StationManager.CurrentWorkshop = CurrentWorkshop;
            obj.Close();
        }
    }
}
