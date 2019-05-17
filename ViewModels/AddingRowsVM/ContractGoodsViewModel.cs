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
        public ObservableCollection<string> ListContracts { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCurtains { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCornices { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListAccs { get; } = new ObservableCollection<string>();

        private string numContract;
        private string nameCurtain;
        private string nameCornice;
        private string nameAccessories;
        private int curtAmount;
        private int cornAmount;
        private int accAmount;

        

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

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('стелеві карнизи', 'настінні карнизи') ", conn);
                SqlDataReader select = query.ExecuteReader(), sql1, sql2, sql3;
                while (select.Read())
                {
                    ListCornices.Add(select["name_g"].ToString().Trim(' '));
                }
                select.Close();
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('тюль', 'портьєрні', 'водовідштовхувальні', 'рулонні', 'жалюзі')", conn);
                sql1 = query.ExecuteReader();
                while (sql1.Read())
                {
                    ListCurtains.Add(sql1["name_g"].ToString().Trim(' '));
                }
                sql1.Close();
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('китиці', 'бахрома', 'люверси', 'тесьма')", conn);
                sql2 = query.ExecuteReader();
                while (sql2.Read())
                {
                    ListAccs.Add(sql2["name_g"].ToString().Trim(' '));
                }
                sql2.Close();
                query = new SqlCommand("SELECT Num_contract FROM Contract", conn);
                sql3 = query.ExecuteReader();
                while (sql3.Read())
                {
                    ListContracts.Add(sql1["Num_contract"].ToString().Trim(' '));
                }
                sql3.Close();
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

        public string NameCurtain
        {
            get => nameCurtain;
            set
            {
                nameCurtain = value;
                OnPropertyChanged();
            }
        }
        public string NameCornice
        {
            get => nameCornice;
            set
            {
                nameCornice = value;
                OnPropertyChanged();
            }
        }
        public string NameAccessories
        {
            get => nameAccessories;
            set
            {
                nameAccessories = value;
                OnPropertyChanged();
            }
        }

        public int CurtAmount
        {
            get => curtAmount;
            set { curtAmount = value; OnPropertyChanged(); }
        }
        public int CornAmount
        {
            get => cornAmount;
            set { cornAmount = value; OnPropertyChanged(); }
        }
        public int AccAmount
        {
            get => accAmount;
            set { accAmount = value; OnPropertyChanged(); }
        }


        public RelayCommand<object> AddContractGoods
        {
            get => addContractGoods ??(addContractGoods = new RelayCommand<object>(AddImpl, CanAdd));
        }
        

        private void AddImpl(object obj)
        {
            string articul = null;
            SqlDataReader reader1, reader2, reader3;
            SqlCommand query1, query2, query3;
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                if (!string.IsNullOrWhiteSpace(NameCurtain))
                {
                    query1 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameCurtain + "'", conn);
                    reader1 = query1.ExecuteReader();

                    while (reader1.Read())
                    {
                        articul = reader1["Articul"].ToString();
                    }
                    reader1.Close();
                    StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, CurtAmount);
                    StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
                    MessageBox.Show("row added");
                }
                if (!string.IsNullOrWhiteSpace(NameCornice))
                {
                    query2 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameCornice + "'", conn);
                    reader2 = query2.ExecuteReader();

                    while (reader2.Read())
                    {
                        articul = reader2["Articul"].ToString();
                    }
                    reader2.Close();
                    StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, CornAmount);
                    StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
                    MessageBox.Show("row added");
                }
                if (!string.IsNullOrWhiteSpace(NameAccessories))
                {
                    query3 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameAccessories + "'", conn);
                    reader3 = query3.ExecuteReader();

                    while (reader3.Read())
                    {
                        articul = reader3["Articul"].ToString();
                    }
                    reader3.Close();
                    StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, AccAmount);
                    StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
                    MessageBox.Show("row added");
                }
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
                   (!string.IsNullOrWhiteSpace(NameCornice) ||
                   !string.IsNullOrWhiteSpace(NameCurtain) ||
                   !string.IsNullOrWhiteSpace(NameAccessories)) &&
                   (!string.IsNullOrWhiteSpace(CurtAmount.ToString()) ||
                   !string.IsNullOrWhiteSpace(CornAmount.ToString()) ||
                   !string.IsNullOrWhiteSpace(AccAmount.ToString()));
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
