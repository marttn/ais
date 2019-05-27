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
    class UpdCustTelVM
    {
        private RelayCommand<object> updTel;

        public UpdCustTelVM()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT last_name, name_cust FROM Customer WHERE ID = '" + CurrentCustTel.ID + "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    Name = select["last_name"].ToString().Trim(' ') + select["name_cust"].ToString().Trim(' ');
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

        public Cust_Tel CurrentCustTel { get; } = StationManager.CurrentCustTel;
        public string Name { get; set; }

        public RelayCommand<object> UpdTel
        {
            get => updTel ?? (updTel = new RelayCommand<object>(UpdImpl, CanUpd));
        }

        private bool CanUpd(object obj)
        {
            return CurrentCustTel.TelNum.Length == 10 &&
                   !string.IsNullOrWhiteSpace(CurrentCustTel.TelNum);
        }

        private void UpdImpl(object obj)
        {
            StationManager.DataStorage.UpdateCustTel(StationManager.CurrentCustTel, CurrentCustTel);
            StationManager.CurrentCustTel = CurrentCustTel;
            NavigationManager.Instance.Navigate(Tools.Navigation.ViewType.Admin);
        }
    }
}
