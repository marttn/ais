using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractorTelVM
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<object> updateContractorTel;

        public string NameContractor { get; set; }
        public Contractor_Tel CurrentContractorTel = StationManager.CurrentContractorTel;

        public UpdContractorTelVM()
        {
            try
            {
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT Name_contr FROM Goods WHERE Code_contractor = '" + CurrentContractorTel.CodeContractor+ "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    NameContractor = select["Name_contr"].ToString().Trim(' ');
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

        public RelayCommand<object> UpdateContractorTel
        {
            get => updateContractorTel ?? (updateContractorTel = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return CurrentContractorTel.TelNum.Length == 10;
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateContractorTel(StationManager.CurrentContractorTel, CurrentContractorTel);
            StationManager.CurrentContractorTel = CurrentContractorTel;
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }

        
    }
}
