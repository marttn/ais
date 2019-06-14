using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    internal class ContractGoodsViewModel
    {
        private RelayCommand<Window> _addContractGoods;
        public ObservableCollection<string> ListContracts { get; }
        public ObservableCollection<string> ListCurtains { get; }
        public ObservableCollection<string> ListCornices { get; }
        public ObservableCollection<string> ListAccs { get; }

        private string _numContract;
        private string _nameCurtain;
        private string _nameCornice;
        private string _nameAccessories;
        private int _curtAmount;
        private int _cornAmount;
        private int _accAmount;

        

    SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractGoodsViewModel()
        {
           ListAccs = new ObservableCollection<string>(StationManager.DataStorage.ListAccs());
           ListContracts = new ObservableCollection<string>(StationManager.DataStorage.ListContracts());
           ListCornices = new ObservableCollection<string>(StationManager.DataStorage.ListCornices());
           ListCurtains = new ObservableCollection<string>(StationManager.DataStorage.ListCurtains());
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

        public string NameCurtain
        {
            get => _nameCurtain;
            set
            {
                _nameCurtain = value;
                OnPropertyChanged();
            }
        }
        public string NameCornice
        {
            get => _nameCornice;
            set
            {
                _nameCornice = value;
                OnPropertyChanged();
            }
        }
        public string NameAccessories
        {
            get => _nameAccessories;
            set
            {
                _nameAccessories = value;
                OnPropertyChanged();
            }
        }

        public int CurtAmount
        {
            get => _curtAmount;
            set { _curtAmount = value; OnPropertyChanged(); }
        }
        public int CornAmount
        {
            get => _cornAmount;
            set { _cornAmount = value; OnPropertyChanged(); }
        }
        public int AccAmount
        {
            get => _accAmount;
            set { _accAmount = value; OnPropertyChanged(); }
        }


        public RelayCommand<Window> AddContractGoods
        {
            get => _addContractGoods ??(_addContractGoods = new RelayCommand<Window>(AddImpl, CanAdd));
        }
        

        private void AddImpl(Window obj)
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
                    query1 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '"+ NameCurtain+"%'", conn);
                    reader1 = query1.ExecuteReader();

                    while (reader1.Read())
                    {
                        articul = reader1["Articul"].ToString();
                    }
                    reader1.Close();
                    StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, CurtAmount);
                    StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
                    
                }
                if (!string.IsNullOrWhiteSpace(NameCornice))
                {
                    query2 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '"+ NameCornice+"%'", conn);
                    reader2 = query2.ExecuteReader();

                    while (reader2.Read())
                    {
                        articul = reader2["Articul"].ToString();
                    }
                    reader2.Close();
                    StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, CornAmount);
                    StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
                    
                }
                if (!string.IsNullOrWhiteSpace(NameAccessories))
                {
                    query3 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '"+ NameAccessories +"%'", conn);
                    reader3 = query3.ExecuteReader();

                    while (reader3.Read())
                    {
                        articul = reader3["Articul"].ToString();
                    }
                    reader3.Close();
                    StationManager.CurrentContractGoods = new Contract_Goods(NumContract, articul, AccAmount);
                    StationManager.DataStorage.AddContractGoods(StationManager.CurrentContractGoods);
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message  + "\n" + exc.Source + "\n"+ exc.StackTrace);
            }
            finally
            {
                conn?.Close();
            }
            obj.Close();
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(NumContract) &&
                   !string.IsNullOrWhiteSpace(NameCurtain) && !string.IsNullOrWhiteSpace(CurtAmount.ToString()) &&
                   CurtAmount > 0 |
                   (!string.IsNullOrWhiteSpace(NameCornice) && !string.IsNullOrWhiteSpace(CornAmount.ToString()) &&
                    CornAmount > 0) |
                   (!string.IsNullOrWhiteSpace(NameAccessories) && !string.IsNullOrWhiteSpace(AccAmount.ToString()) &&
                    AccAmount > 0);
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
