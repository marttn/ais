using System.Text.RegularExpressions;
using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdGoodsVM
    {
        private RelayCommand<Window> _updateGoods;
        public Goods CurrentGoods { get; } = StationManager.CurrentGoods;

        public RelayCommand<Window> UpdateGoods => _updateGoods ?? (_updateGoods = new RelayCommand<Window>(UpdImpl, CanUpd));

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateGoods(StationManager.CurrentGoods, CurrentGoods);
            StationManager.CurrentGoods = CurrentGoods;
            obj.Close();
        }

        private bool CanUpd(Window obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentGoods.Name) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentGoods.Characteristics)
                   && CurrentGoods.Characteristics.Length <= 255;
        }
    }
}
