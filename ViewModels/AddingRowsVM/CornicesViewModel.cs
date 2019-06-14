using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels.AddingRowsVM
{
    class CornicesViewModel
    {
        private RelayCommand<Window> _addCornices;
        public Cornices CurrentCornices { get; }

        public CornicesViewModel()
        {
            CurrentCornices = new Cornices();
            StationManager.CurrentCornices = CurrentCornices;
        }

        public RelayCommand<Window> AddCornices
        {
            get => _addCornices ?? (_addCornices = new RelayCommand<Window>(AddCorniceImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return new Regex("^\\d{10}").IsMatch(CurrentCornices.Ipn)  &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.LastName) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.Name) &&
                   (CurrentCornices.Building == null || CurrentCornices.Building.Length <= 4) &&
                   (CurrentCornices.Building == null || new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.MiddleName)) &&
                   (CurrentCornices.City== null || new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.City)) &&
                   (CurrentCornices.Street == null || new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentCornices.Street)) &&
                   new Regex("^\\d{16}").IsMatch(CurrentCornices.AccountCornice) &&
                   new Regex("^\\d{10}").IsMatch(CurrentCornices.TelNum)  &&
                   !string.IsNullOrWhiteSpace(CurrentCornices.PriceOneCornice.ToString(CultureInfo.InvariantCulture)) && CurrentCornices.PriceOneCornice > 0;
        }

        private void AddCorniceImpl(Window obj)
        {
            StationManager.DataStorage.AddCornices(StationManager.CurrentCornices);
            obj.Close();
        }
    }
}
