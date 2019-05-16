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
    class ContractGoodsViewModel
    {
        private RelayCommand<object> addContractGoods;
        public ObservableCollection<string> ListGoods { get; } = new ObservableCollection<string>();

        private string numContract;
        private string name;
        private int quantity;

        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractGoodsViewModel()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    ListGoods.Add(select["name_g"].ToString().Trim(' '));
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
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged();
            }
        }
        

        public RelayCommand<object> AddContractGoods
        {
            get => addContractGoods ??(addContractGoods = new RelayCommand<object>(AddImpl, CanAdd));
        }

        private void AddImpl(object obj)
        {
            try
            {
                string articul = null;
                SqlDataReader reader;
                SqlCommand query;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                query = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + Name + "'", conn);
                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    articul = reader["Articul"].ToString();
                }
                reader.Close();

                StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, Quantity);
                StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
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
                   !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Quantity.ToString());
        }



        #region INotifyPropertyChang
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
