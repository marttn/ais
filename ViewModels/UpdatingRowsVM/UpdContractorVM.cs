using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Text.RegularExpressions;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractorVM
    {
        private RelayCommand<Window> _updateContractor;

        
        public Contractor CurrentContractor { get; } = StationManager.CurrentContractor;

        public RelayCommand<Window> UpdateContractor
        {
            get => _updateContractor ?? (_updateContractor = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
        {
            return new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentContractor.NameContractor) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentContractor.City) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentContractor.Street) &&
                   new Regex("^\\d+[a-zA-ZА-Яа-я]*$").IsMatch(CurrentContractor.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Porch.ToString()) && CurrentContractor.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Office.ToString()) &&
                   new Regex("^\\d{16}").IsMatch(CurrentContractor.Account) &&
                   new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(CurrentContractor.Email);
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateContractor(StationManager.CurrentContractor, CurrentContractor);
            StationManager.CurrentContractor = CurrentContractor;
            obj.Close();
        }
    }
}
