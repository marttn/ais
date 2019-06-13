using System.Globalization;
using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;

namespace ais.ViewModels.AddingRowsVM
{
    class CornicesViewModel
    {
        private RelayCommand<Window> addCornices;
        public Cornices CurrentCornices { get; }

        public CornicesViewModel()
        {
            CurrentCornices = new Cornices();
            StationManager.CurrentCornices = CurrentCornices;
        }

        public RelayCommand<Window> AddCornices
        {
            get => addCornices ?? (addCornices = new RelayCommand<Window>(AddCorniceImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCornices.Ipn) && (CurrentCornices.Ipn.Length == 10) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.Name) && (CurrentCornices.Building == null || CurrentCornices.Building.Length <= 4) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.AccountCornice) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.TelNum) && CurrentCornices.TelNum.Length==10 &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.PriceOneCornice.ToString(CultureInfo.InvariantCulture)) && CurrentCornices.PriceOneCornice > 0;
        }

        private void AddCorniceImpl(Window obj)
        {
            StationManager.DataStorage.AddCornices(StationManager.CurrentCornices);
            obj.Close();
        }
    }
}
