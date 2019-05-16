using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.ViewModels.AddingRowsVM
{
    class GoodsViewModel
    {
        private RelayCommand<object> addGoods;
        public Goods CurrentGoods { get; }

        public GoodsViewModel()
        {
            CurrentGoods = new Goods();
            StationManager.CurrentGoods = CurrentGoods;
        }

        public RelayCommand<object> AddGoods
        {
            get => addGoods ?? (addGoods = new RelayCommand<object>(AddGoodsImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentGoods.Articul) &&
                   !string.IsNullOrWhiteSpace(CurrentGoods.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentGoods.Type) &&
                   !string.IsNullOrWhiteSpace(CurrentGoods.Material) &&
                   !string.IsNullOrWhiteSpace(CurrentGoods.Characteristics);
        }

        private void AddGoodsImpl(object obj)
        {
            StationManager.DataStorage.AddGoods(StationManager.CurrentGoods);
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }
    }
}
