using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;

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

        public RelayCommand<Window> AddContractor
        {
            get => _addContractor ?? (_addContractor = new RelayCommand<Window>(AddContractorImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentContractor.CodeContractor) && CurrentContractor.CodeContractor.Length == 8 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.NameContractor) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.City) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Porch.ToString()) && CurrentContractor.Building.Length <= 4 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Office.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Account) && CurrentContractor.Account.Length == 16 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Email);
        }

        private void AddContractorImpl(Window obj)
        {
            StationManager.DataStorage.AddContractor(StationManager.CurrentContractor);
            obj.Close();
        }
    }
}
