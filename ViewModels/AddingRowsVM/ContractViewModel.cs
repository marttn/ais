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
        private RelayCommand<Window> _addContract;
        public ObservableCollection<string> ListContractors { get; }

        private string _numContract;
        private DateTime _dateContract;
        private string _nameContr;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractViewModel()
        {
            ListContractors = new ObservableCollection<string>(StationManager.DataStorage.NameContractors());
        }

        public string NumContract
        {
            get => _numContract;
            set
            {
                _numContract = value;
                OnPropertyChanged();
            }
        }
        public DateTime DateContract
        {
            get => _dateContract;
            set
            {
                _dateContract = value;
                OnPropertyChanged();
            }
        }
        public string NameContr
        {
            get => _nameContr;
            set
            {
                _nameContr = value;
                OnPropertyChanged();
            }
        }

       
        public RelayCommand<Window> AddContract
        {
            get => _addContract ?? (_addContract = new RelayCommand<Window>(AddContractImpl, CanAdd));
        }

        private void AddContractImpl(Window obj)
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
                
                    query = new SqlCommand("SELECT Code_contractor FROM Contractor WHERE Name_contr like '" + NameContr + "%'", conn);
                    reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        code = reader["Code_contractor"].ToString();
                    }
                    reader.Close();

                StationManager.CurrentContract = new Contract(NumContract, DateContract, code);
                StationManager.DataStorage.AddContract(StationManager.CurrentContract);
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                conn.Close();
            }
            obj.Close();
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
