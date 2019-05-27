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
    class UpdContractVM
    {
        
        public UpdContractVM()
        {
            try
            {
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT Name_contr FROM Contractor WHERE Code_contractor = '" + CurrentContract.CodeContractor + "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    NameContr = select["Name_contr"].ToString().Trim(' ');
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

        private RelayCommand<object> updateContract;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public Contract CurrentContract { get; } = StationManager.CurrentContract;
        public string NameContr { get; set; }

        public RelayCommand<object> UpdateContract
        {
            get => updateContract ?? (updateContract = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return CurrentContract.DateContract <= DateTime.Now;
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateContract(StationManager.CurrentContract, CurrentContract);
            StationManager.CurrentContract = CurrentContract;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
