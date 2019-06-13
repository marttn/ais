using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdCornicesVM
    {

        private RelayCommand<Window> _updateCornices;
        public Cornices CurrentCornices { get; } = StationManager.CurrentCornices;

        public RelayCommand<Window> UpdateCornices
        {
            get => _updateCornices ?? (_updateCornices = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentCornices.LastName) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.AccountCornice) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.TelNum) &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.PriceOneCornice.ToString()) && CurrentCornices.PriceOneCornice != 0.0;
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateCornices(StationManager.CurrentCornices, CurrentCornices);
            StationManager.CurrentCornices = CurrentCornices;
            obj.Close();
        }
    }
}
