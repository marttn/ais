using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class ContractorTelViewModel
    {
        private string name;
        private string tel;

        private RelayCommand<object> addTel;


        public string Name
        {
            get => name ?? (name = StationManager.CurrentContractor.NameContractor);
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Tel
        {
            get => tel;
            set
            {
                tel = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> AddTel
        {
            get => addTel ?? (addTel = new RelayCommand<object>(AddTelImpl, CanAdd));
        }

        private void AddTelImpl(object obj)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                string code = "";
                SqlCommand query = new SqlCommand("SELECT Code_contractor FROM Contractor WHERE Name_contr = '" + Name.Trim(' ') + "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    code = select["Code_contractor"].ToString();
                }
                select.Close();
                StationManager.CurrentContractorTel = new Contractor_Tel(Tel, code);
                StationManager.DataStorage.AddContractorTel(StationManager.CurrentContractorTel);

            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            NavigationManager.Instance.Navigate(ViewType.Admin);
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(Tel) && (Tel.Length == 10);
        }



        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
