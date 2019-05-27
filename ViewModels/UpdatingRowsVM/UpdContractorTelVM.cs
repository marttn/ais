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
    class UpdContractorTelVM
    {
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<object> updateContractorTel;

        public string NameContractor { get; }
        public Contractor_Tel CurrentContractorTel = StationManager.CurrentContractorTel;

        public UpdContractorTelVM()
        {
            try
            {
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT Name_contr FROM Goods WHERE Code_contractor = '" + CurrentContractorTel.Articul + "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    NameGoods = select["name_g"].ToString().Trim(' ');
                }
                select.Close();
                query = new SqlCommand("SELECT Name_contr FROM Goods WHERE Code_contractor = '" + CurrentContractorGoods.CodeContractor + "'", conn);
                
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
            throw new NotImplementedException();
        }

        private void UpdImpl(object obj)
        {
            throw new NotImplementedException();
        }

        
    }
}
