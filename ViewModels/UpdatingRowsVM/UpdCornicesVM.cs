using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Globalization;
using System.Text.RegularExpressions;

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
            return new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.LastName) &&
                new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.Name) &&
                (CurrentCornices.Building == null || CurrentCornices.Building.Length <= 4) &&
                (CurrentCornices.Building == null || new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.MiddleName)) &&
                (CurrentCornices.City == null || new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.City)) &&
                (CurrentCornices.Street == null || new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.Street)) &&
                new Regex("^\\d{16}").IsMatch(CurrentCornices.AccountCornice) &&
                new Regex("^\\d{10}").IsMatch(CurrentCornices.TelNum) &&
                !string.IsNullOrWhiteSpace(CurrentCornices.PriceOneCornice.ToString(CultureInfo.InvariantCulture)) && CurrentCornices.PriceOneCornice > 0;
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateCornices(StationManager.CurrentCornices, CurrentCornices);
            StationManager.CurrentCornices = CurrentCornices;
            obj.Close();
        }
    }
}
