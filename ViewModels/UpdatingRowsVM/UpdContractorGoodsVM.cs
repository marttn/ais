using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractorGoodsVM
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<object> updateContractorGoods;

        public UpdContractorGoodsVM()
        {
            try
            {
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE Articul = '" + CurrentContractorGoods.Articul + "'", conn);
                SqlDataReader select = query.ExecuteReader(), select1;
                while (select.Read())
                {
                    NameGoods = select["name_g"].ToString().Trim(' ');
                }
                select.Close();
                query = new SqlCommand("SELECT Name_contr FROM Contractor WHERE Code_contractor = '" + CurrentContractorGoods.CodeContractor + "'", conn);
                select1 = query.ExecuteReader();
                while (select1.Read())
                {
                    NameContractor = select1["Name_contr"].ToString().Trim(' ');
                }
                select1.Close();
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

        public Contractor_Goods CurrentContractorGoods { get; } = StationManager.CurrentContractorGoods;
        public string NameGoods { get; set; }
        public string NameContractor { get; set; }

        public RelayCommand<object> UpdateContractorGoods
        {
            get => updateContractorGoods ?? (updateContractorGoods = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateContractorGoods(StationManager.CurrentContractorGoods, CurrentContractorGoods);
            StationManager.CurrentContractorGoods = CurrentContractorGoods;
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }

        private bool CanUpd(object obj)
        {
            return CurrentContractorGoods.PriceOneProduct > 0;
        }
    }
}
