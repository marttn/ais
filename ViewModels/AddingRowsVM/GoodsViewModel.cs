using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Text.RegularExpressions;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class GoodsViewModel
    {
        private RelayCommand<Window> _addGoods;
        public Goods CurrentGoods { get; }

        public GoodsViewModel()
        {
            CurrentGoods = new Goods();
            StationManager.CurrentGoods = CurrentGoods;
        }

        public RelayCommand<Window> AddGoods => _addGoods ?? (_addGoods = new RelayCommand<Window>(AddGoodsImpl, CanAdd));

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(CurrentGoods.Name) &&
                   !string.IsNullOrWhiteSpace(CurrentGoods.Type) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentGoods.Material) &&
                   new Regex("^[a-zA-ZА-Яа-я]+$").IsMatch(CurrentGoods.Characteristics) 
                   && CurrentGoods.Characteristics.Length <= 255;
        }

        private void AddGoodsImpl(Window obj)
        {
            StationManager.DataStorage.AddGoods(StationManager.CurrentGoods);
            obj.Close();
        }
    }
}
