using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdOrderGoodsVM
    {
        private RelayCommand<object> updateOrderGoods;

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

        public RelayCommand<object> UpdateOrderGoods
        {
            get => updateOrderGoods ?? (updateOrderGoods = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return CurrentOrderGoods.QuantityGoods > 0;
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateOrderGoods(StationManager.CurrentOrderGoods, CurrentOrderGoods);
            StationManager.CurrentOrderGoods = CurrentOrderGoods;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
