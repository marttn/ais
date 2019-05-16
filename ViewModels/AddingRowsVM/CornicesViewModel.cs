using ais.Models;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels.AddingRowsVM
{
    class CornicesViewModel
    {
        private RelayCommand<object> addCornices;
        public Cornices CurrentCornices { get; }

        public CornicesViewModel()
        {
            CurrentCornices = new Cornices();
            StationManager.CurrentCornices = CurrentCornices;
        }

        public RelayCommand<object> AddCornices
        {
            get => addCornices ?? (addCornices = new RelayCommand<object>(AddCorniceImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCornices.Ipn) && (CurrentCornices.Ipn.Length == 10) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.AccountCornice) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.TelNum) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.PriceOneCornice.ToString()) && CurrentCornices.PriceOneCornice != 0;
        }

        private void AddCorniceImpl(object obj)
        {
            StationManager.DataStorage.AddCornices(StationManager.CurrentCornices);
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
