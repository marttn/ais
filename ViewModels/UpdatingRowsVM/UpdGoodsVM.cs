using System;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdGoodsVM
    {
        private RelayCommand<object> updateGoods;
        public Goods CurrentGoods { get; } = StationManager.CurrentGoods;

        public RelayCommand<object> UpdateGoods
        {
            get => updateGoods ?? (updateGoods = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateGoods(StationManager.CurrentGoods, CurrentGoods);
            StationManager.CurrentGoods = CurrentGoods;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }

        private bool CanUpd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentGoods.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentGoods.Characteristics)
                   && CurrentGoods.Characteristics.Length <= 255;
        }
    }
}
