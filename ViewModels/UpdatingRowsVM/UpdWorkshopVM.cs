using System.Globalization;
using System.Text.RegularExpressions;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;

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
            return new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentWorkshop.Name) &&
                   new Regex("^\\d{10}").IsMatch(CurrentWorkshop.TelNum) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentWorkshop.City) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentWorkshop.Street) &&
                   new Regex("^\\d+[a-zA-ZА-Яа-я]*$").IsMatch(CurrentWorkshop.Building) && CurrentWorkshop.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Office.ToString()) && CurrentWorkshop.Office != 0 &&
                   new Regex("^\\d{16}").IsMatch(CurrentWorkshop.AccountShop) &&
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
