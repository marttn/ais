using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Data.SqlClient;
using System.Windows;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractGoodsVM
    {
        public UpdContractGoodsVM()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE Articul = '" + CurrentContractGoods.Articul+ "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                   Name =  select["name_g"].ToString().Trim(' ');
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

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<object> updateContractGoods;

        public Contract_Goods CurrentContractGoods { get; } = StationManager.CurrentContractGoods;
        public string Name { get; set; }

        public RelayCommand<object> UpdateContractGoods
        {
            get => updateContractGoods ?? (updateContractGoods = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateContractGoods(StationManager.CurrentContractGoods, CurrentContractGoods);
            StationManager.CurrentContractGoods = CurrentContractGoods;
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }

        private bool CanUpd(object obj)
        {
            return CurrentContractGoods.Quantity > 0;
        }
    }
}
