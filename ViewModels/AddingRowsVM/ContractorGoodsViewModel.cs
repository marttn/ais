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
    class ContractorGoodsViewModel
    {
        public ObservableCollection<string> ListContractors { get; }
        public ObservableCollection<string> ListCurtains { get; }
        public ObservableCollection<string> ListCornices { get; }
        public ObservableCollection<string> ListAccs { get; }

        private string nameContractor;
        private string nameCurtain;
        private string nameCornice;
        private string nameAccessories;
        private int curtPrice;
        private int cornPrice;
        private int accPrice;

        private RelayCommand<Window> addContractorGoods;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractorGoodsViewModel()
        {
            ListContractors = new ObservableCollection<string>(StationManager.DataStorage.NameContractors());
            ListCurtains = new ObservableCollection<string>(StationManager.DataStorage.ListCurtains());
            ListCornices = new ObservableCollection<string>(StationManager.DataStorage.ListCornices());
            ListAccs = new ObservableCollection<string>(StationManager.DataStorage.ListAccs());
        }

        

        public string NameContractor
        {
            get => nameContractor;
            set
            {
                nameContractor = value;
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

        public int CurtPrice
        {
            get => curtPrice;
            set { curtPrice = value; OnPropertyChanged(); }
        }
        public int CornPrice
        {
            get => cornPrice;
            set { cornPrice = value; OnPropertyChanged(); }
        }
        public int AccPrice
        {
            get => accPrice;
            set { accPrice = value; OnPropertyChanged(); }
        }


        public RelayCommand<Window> AddContractorGoods
        {
            get => addContractorGoods ?? (addContractorGoods = new RelayCommand<Window>(AddImpl, CanAdd));
        }

        private bool CanAdd(Window obj)
        {
            return (!string.IsNullOrWhiteSpace(NameAccessories) ||
                   !string.IsNullOrWhiteSpace(NameCurtain) ||
                   !string.IsNullOrWhiteSpace(NameCornice)) &&
                   !string.IsNullOrWhiteSpace(NameContractor) &&
                   ((!string.IsNullOrWhiteSpace(CornPrice.ToString()) && CornPrice > 0) ||
                   (!string.IsNullOrWhiteSpace(CurtPrice.ToString()) && CurtPrice > 0) ||
                   (!string.IsNullOrWhiteSpace(AccPrice.ToString()) && AccPrice > 0));
        }

        private void AddImpl(Window obj)
        {
            try
            {
                string articul = null, code = null;
                SqlDataReader reader1, reader2, reader3, reader4;
                SqlCommand query;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                //contractor
                query = new SqlCommand("SELECT Code_contractor FROM Contractor WHERE Name_contr = '" + NameContractor + "'", conn);
                reader4 = query.ExecuteReader();
                while (reader4.Read())
                {
                    code = reader4["Code_contractor"].ToString();
                }
                reader4.Close();
                //curtain
                if (!string.IsNullOrWhiteSpace(NameCurtain))
                {
                    query = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameCurtain + "'", conn);
                    reader1 = query.ExecuteReader();

                    while (reader1.Read())
                    {
                        articul = reader1["Articul"].ToString();
                    }
                    reader1.Close();
                    if (StationManager.DataStorage.ContractorGoodsList.Exists(u => u.CodeContractor.Trim(' ').Equals(code) &&                    
                    u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Price for "+NameCurtain+ " is already set by " + NameContractor);
                    }
                    else
                    {
                        StationManager.CurrentContractorGoods = new Contractor_Goods(articul, code, CurtPrice);
                        StationManager.DataStorage.AddContractorGoods(StationManager.CurrentContractorGoods);
                        MessageBox.Show("row added");
                    }
                    
                }
                //cornices
                if (!string.IsNullOrWhiteSpace(NameCornice))
                {
                    query = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameCornice + "'", conn);
                    reader2 = query.ExecuteReader();

                    while (reader2.Read())
                    {
                        articul = reader2["Articul"].ToString();
                    }
                    reader2.Close();
                    if (StationManager.DataStorage.ContractorGoodsList.Exists(u => u.CodeContractor.Trim(' ').Equals(code) &&
                    u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Price for " + NameCornice + " is already set by " + NameContractor);
                    }
                    else
                    {
                        StationManager.CurrentContractorGoods = new Contractor_Goods(articul, code, CornPrice);
                        StationManager.DataStorage.AddContractorGoods(StationManager.CurrentContractorGoods);
                        MessageBox.Show("row added");
                    }
                }
                //accessories
                if (!string.IsNullOrWhiteSpace(NameAccessories))
                {
                    query = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameAccessories + "'", conn);
                    reader3 = query.ExecuteReader();

                    while (reader3.Read())
                    {
                        articul = reader3["Articul"].ToString();
                    }
                    reader3.Close();
                    if (StationManager.DataStorage.ContractorGoodsList.Exists(u => u.CodeContractor.Trim(' ').Equals(code) &&
                    u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Price for " + NameAccessories+ " is already set by " + NameContractor);
                    }
                    else
                    {
                        StationManager.CurrentContractorGoods = new Contractor_Goods(articul, code, AccPrice);
                        StationManager.DataStorage.AddContractorGoods(StationManager.CurrentContractorGoods);
                        MessageBox.Show("row added");
                    }
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
            obj.Close();
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
