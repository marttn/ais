﻿using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Data.SqlClient;
using ais.Tools.Navigation;
using System;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdOrderGoodsVM
    {
        private RelayCommand<Window> _updateOrderGoods;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public UpdOrderGoodsVM()
        {
            try
            {
                conn.Open();
                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE Articul = '" + CurrentOrderGoods.Articul + "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    NameGoods = select["name_g"].ToString().Trim(' ');
                }
                select.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public Order_Goods CurrentOrderGoods { get; } = StationManager.CurrentOrderGoods;
        public string NameGoods { get; set; }

        public RelayCommand<Window> UpdateOrderGoods
        {
            get => _updateOrderGoods ?? (_updateOrderGoods = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
        {
            return CurrentOrderGoods.QuantityGoods > 0;
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateOrderGoods(StationManager.CurrentOrderGoods, CurrentOrderGoods);
            StationManager.CurrentOrderGoods = CurrentOrderGoods;
            obj.Close();
        }
    }
}
