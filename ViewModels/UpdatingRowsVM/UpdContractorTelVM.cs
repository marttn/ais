using System;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdContractorTelVM
    {
        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        private RelayCommand<Window> _updateContractorTel;

        public string NameContractor { get; set; }
        public Contractor_Tel CurrentContractorTel { get; }= StationManager.CurrentContractorTel;

        public UpdContractorTelVM()
        {
            try
            {
                _conn.Open();

                SqlCommand query = new SqlCommand("SELECT Name_contr FROM Contractor WHERE Code_contractor like '" + CurrentContractorTel.CodeContractor+ "%'", _conn);
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
                _conn.Close();
            }
        }

        public RelayCommand<Window> UpdateContractorTel => _updateContractorTel ?? (_updateContractorTel = new RelayCommand<Window>(UpdImpl, CanUpd));

        private bool CanUpd(Window obj) => new Regex("\\d{10}").IsMatch(CurrentContractorTel.TelNum);

        private void UpdImpl(Window obj)
        {
            StationManager.DataStorage.UpdateContractorTel(StationManager.CurrentContractorTel, CurrentContractorTel);
            StationManager.CurrentContractorTel = CurrentContractorTel;
            obj.Close();
        }

        
        
    }
}
