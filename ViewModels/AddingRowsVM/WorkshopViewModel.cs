using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.ViewModels.AddingRowsVM
{
    class WorkshopViewModel
    {
        private RelayCommand<object> addWorkshop;
        public Workshop CurrentWorkshop;

        public WorkshopViewModel()
        {
            CurrentWorkshop = new Workshop();
            StationManager.CurrentWorkshop = CurrentWorkshop;
        }

        public RelayCommand<object> AddWorkshop
        {
            get => addWorkshop ?? (addWorkshop = new RelayCommand<object>(AddWorkshopImpl, CanAdd));
        }

        private void AddWorkshopImpl(object obj)
        {
            StationManager.DataStorage.AddWorkshop(StationManager.CurrentWorkshop);
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentWorkshop.CodeWorkshop) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.TelNum) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.City) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Office.ToString()) && CurrentWorkshop.Office != 0 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.AccountShop) &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.PriceOneCurtain.ToString()) && CurrentWorkshop.PriceOneCurtain != 0;
        }
    }
}
