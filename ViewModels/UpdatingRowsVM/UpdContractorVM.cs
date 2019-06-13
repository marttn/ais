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
    class UpdContractorVM
    {
        private RelayCommand<Window> updateContractor;

        
        public Contractor CurrentContractor { get; } = StationManager.CurrentContractor;

        public RelayCommand<Window> UpdateContractor
        {
            get => updateContractor ?? (updateContractor = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentContractor.NameContractor) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.City) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Street) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Building) && CurrentContractor.Building.Length <=4 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Porch.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Office.ToString()) &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Account) && CurrentContractor.Account.Length == 16 &&
                   !string.IsNullOrWhiteSpace(CurrentContractor.Email);
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateContractor(StationManager.CurrentContractor, CurrentContractor);
            StationManager.CurrentContractor = CurrentContractor;
            obj.Close();
        }
    }
}
