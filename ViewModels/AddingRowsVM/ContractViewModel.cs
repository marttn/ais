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
    class ContractViewModel
    {
        private RelayCommand<object> addContract;
        public ObservableCollection<string> ListContractors { get; } = new ObservableCollection<string>();

        private string numContract;
        private DateTime dateContract;
        private string nameContr;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractViewModel()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT Name_contr FROM Contractor", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    ListContractors.Add(select["Name_contr"].ToString().Trim(' '));
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

        public string NumContract
        {
            get => numContract;
            set
            {
                numContract = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateContract
        {
            get => dateContract;
            set
            {
                dateContract = value;
                OnPropertyChanged();
            }
        }
        public string NameContr
        {
            get => nameContr;
            set
            {
                nameContr = value;
                OnPropertyChanged();
            }
        }

       
        public RelayCommand<object> AddContract
        {
            get => addContract ?? (addContract = new RelayCommand<object>(AddContractImpl, CanAdd));
        }

        private void AddContractImpl(object obj)
        {
            try
            {
                string code = null;
                SqlDataReader reader;
                SqlCommand query;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                
                    query = new SqlCommand("SELECT Code_contractor FROM Contractor WHERE Name_contr = '" + NameContr + "'", conn);
                    reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        code = reader["Code_contractor"].ToString();
                    }
                    reader.Close();

                StationManager.CurrentContract = new Contract(NumContract, DateContract, code);
                StationManager.DataStorage.AddContract(StationManager.CurrentContract);
                MessageBox.Show("row added");
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
            return !string.IsNullOrWhiteSpace(NumContract) &&
                   !string.IsNullOrWhiteSpace(NameContr);
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
