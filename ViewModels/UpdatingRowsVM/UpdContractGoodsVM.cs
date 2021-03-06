﻿using System;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Data.SqlClient;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractGoodsVM
    {
        public UpdContractGoodsVM()
        {
            try
            {
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE Articul like '" + CurrentContractGoods.Articul+ "%'", _conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                   Name =  select["name_g"].ToString().Trim(' ');
                }
                select.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message  + "\n" + exc.Source + "\n"+ exc.StackTrace);
            }
            finally
            {
                _conn?.Close();
            }
        }

        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<Window> _updateContractGoods;

        public Contract_Goods CurrentContractGoods { get; } = StationManager.CurrentContractGoods;
        public string Name { get; set; }

        public RelayCommand<Window> UpdateContractGoods => _updateContractGoods ?? (_updateContractGoods = new RelayCommand<Window>(UpdImpl, CanUpd));

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateContractGoods(StationManager.CurrentContractGoods, CurrentContractGoods);
            StationManager.CurrentContractGoods = CurrentContractGoods;
            StationManager.DataStorage.UpdateContractGoodsList();
            obj.Close();
        }

        private bool CanUpd(Window obj)
        {
            return CurrentContractGoods.Quantity > 0;
        }
    }
}
