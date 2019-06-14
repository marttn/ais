using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            return new Regex("^\\d{8}").IsMatch(CurrentWorkshop.CodeWorkshop)  &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentWorkshop.Name) &&
                   new Regex("^\\d{10}").IsMatch(CurrentWorkshop.TelNum) && 
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentWorkshop.City) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentWorkshop.Street) &&
                   new Regex("^\\d+[a-zA-ZА-Яа-я]*$").IsMatch(CurrentWorkshop.Building) && CurrentWorkshop.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.Office.ToString()) && CurrentWorkshop.Office != 0 &&
                   new Regex("^\\d{16}").IsMatch(CurrentWorkshop.AccountShop)  &&
                   !string.IsNullOrWhiteSpace(CurrentWorkshop.PriceOneCurtain.ToString(CultureInfo.InvariantCulture)) && CurrentWorkshop.PriceOneCurtain > 0;
        }
    }
}
