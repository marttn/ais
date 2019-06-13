using System;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Data.SqlClient;

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

        private RelayCommand<Window> _updateContract;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public Contract CurrentContract { get; } = StationManager.CurrentContract;
        public string NameContr { get; set; }

        public RelayCommand<Window> UpdateContract => _updateContract ?? (_updateContract = new RelayCommand<Window>(UpdImpl, CanUpd));

        private bool CanUpd(Window obj)
        {
            return CurrentContract.DateContract <= DateTime.Now;
        }

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateContract(StationManager.CurrentContract, CurrentContract);
            StationManager.CurrentContract = CurrentContract;
            obj.Close();
        }
    }
}
