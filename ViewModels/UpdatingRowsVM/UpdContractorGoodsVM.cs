using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Data.SqlClient;
using System;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractorGoodsVM
    {
        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<Window> _updateContractorGoods;

        public UpdContractorGoodsVM()
        {
            try
            {
                _conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE Articul like '" + CurrentContractorGoods.Articul + "%'", _conn);
                SqlDataReader select = query.ExecuteReader(), select1;
                while (select.Read())
                {
                    NameGoods = select["name_g"].ToString().Trim(' ');
                }
                select.Close();
                query = new SqlCommand("SELECT Name_contr FROM Contractor WHERE Code_contractor like '" + CurrentContractorGoods.CodeContractor + "%'", _conn);
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
                _conn.Close();
            }
        }

        public Contractor_Goods CurrentContractorGoods { get; } = StationManager.CurrentContractorGoods;
        public string NameGoods { get; set; }
        public string NameContractor { get; set; }

        public RelayCommand<Window> UpdateContractorGoods => _updateContractorGoods ?? (_updateContractorGoods = new RelayCommand<Window>(UpdImpl, CanUpd));

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateContractorGoods(StationManager.CurrentContractorGoods, CurrentContractorGoods);
            StationManager.CurrentContractorGoods = CurrentContractorGoods;
            obj.Close();
        }

        private bool CanUpd(Window obj)
        {
            return CurrentContractorGoods.PriceOneProduct > 0;
        }
    }
}
