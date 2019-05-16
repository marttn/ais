using ais.Models;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels.AddingRowsVM
{
    class ContractorViewModel
    {
        private RelayCommand<object> addContractor;
        public Contractor CurrentContractor { get; }

        public ContractorViewModel()
        {
            CurrentContractor = new Contractor();
            StationManager.CurrentContractor = CurrentContractor;
        }

        public RelayCommand<object> AddContractor
        {
            get => addContractor ?? (addContractor = new RelayCommand<object>(AddContractorImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentContractor.CodeContractor) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.NameContractor) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.City) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Building) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Office.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Account) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Email);
        }

        private void AddContractorImpl(object obj)
        {
            StationManager.DataStorage.AddContractor(StationManager.CurrentContractor);
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
