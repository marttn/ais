using System.Text.RegularExpressions;
using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels.AddingRowsVM
{
    class ContractorViewModel
    {
        private RelayCommand<Window> _addContractor;
        public Contractor CurrentContractor { get; }

        public ContractorViewModel()
        {
            CurrentContractor = new Contractor();
            StationManager.CurrentContractor = CurrentContractor;
        }

        public RelayCommand<Window> AddContractor => _addContractor ?? (_addContractor = new RelayCommand<Window>(AddContractorImpl, CanAdd));

        private bool CanAdd(object obj)
        {
            return  new Regex("^\\d{8}").IsMatch(CurrentContractor.CodeContractor) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentContractor.NameContractor) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentContractor.City) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentContractor.Street) &&
                   new Regex("^\\d+[a-zA-ZА-Яа-я]*$").IsMatch(CurrentContractor.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Porch.ToString()) && CurrentContractor.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Office.ToString()) &&
                   new Regex("^\\d{16}").IsMatch(CurrentContractor.Account) &&
                   new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(CurrentContractor.Email);
        }

        private void AddContractorImpl(Window obj)
        {
            StationManager.DataStorage.AddContractor(StationManager.CurrentContractor);
            obj.Close();
        }
    }
}
