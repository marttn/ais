using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class WorkshopViewModel
    {
        private RelayCommand<Window> addWorkshop;
        public Workshop CurrentWorkshop;

        public WorkshopViewModel()
        {
            CurrentWorkshop = new Workshop();
            StationManager.CurrentWorkshop = CurrentWorkshop;
        }

        public RelayCommand<Window> AddWorkshop
        {
            get => addWorkshop ?? (addWorkshop = new RelayCommand<Window>(AddWorkshopImpl, CanAdd));
        }

        private void AddWorkshopImpl(Window obj)
        {
            StationManager.DataStorage.AddWorkshop(StationManager.CurrentWorkshop);
            obj.Close();
        }


        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentWorkshop.CodeWorkshop) && CurrentWorkshop.CodeWorkshop.Length == 10 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.TelNum) && CurrentWorkshop.TelNum.Length == 10 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.City) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Building) && CurrentWorkshop.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Office.ToString()) && CurrentWorkshop.Office != 0 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.AccountShop) && CurrentWorkshop.AccountShop.Length == 16 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.PriceOneCurtain.ToString()) && CurrentWorkshop.PriceOneCurtain != 0;
        }
    }
}
