using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class ContractorTelViewModel
    {
        private string name;
        private string selectedName;
        private string tel;

        private RelayCommand<object> addTel;
        private RelayCommand<object> addTelSelected;

        public ObservableCollection<string> ContractorsList { get; } = new ObservableCollection<string>();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);


        public ContractorTelViewModel()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query1 = new SqlCommand("SELECT Name_contr FROM Contractor", conn);
                SqlDataReader select1 = query1.ExecuteReader();
                while (select1.Read())
                {
                    ContractorsList.Add(select1["Name_contr"].ToString().Trim(' '));
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

        public string SelectedName
        {
            get => selectedName;
            set
            {
                selectedName = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> AddTel
        {
            get => addTel ?? (addTel = new RelayCommand<object>(AddTelImpl, CanAdd));
        }
        public RelayCommand<object> AddTelSelected
        {
            get => addTelSelected ?? (addTelSelected = new RelayCommand<object>(AddSelTelImpl, CanAddSelected));
        }

        private void AddTelImpl(object obj)
        {
           
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

        private void AddSelTelImpl(object obj)
        {
           
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                string code = "";
                SqlCommand query = new SqlCommand("SELECT Code_contractor FROM Contractor WHERE Name_contr = '" + SelectedName.Trim(' ') + "'", conn);
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
        private bool CanAddSelected(object obj)
        {
            return !string.IsNullOrWhiteSpace(Tel) && (Tel.Length == 10) &&
                   !string.IsNullOrWhiteSpace(SelectedName);
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
