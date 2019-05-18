using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class ContractorGoodsViewModel
    {
        public ObservableCollection<string> ListContractors { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCurtains { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCornices { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListAccs { get; } = new ObservableCollection<string>();

        private string nameContractor;
        private string nameCurtain;
        private string nameCornice;
        private string nameAccessories;
        private int curtPrice;
        private int cornPrice;
        private int accPrice;

        private RelayCommand<object> addContractorGoods;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public ContractorGoodsViewModel()
        {
            LoadComboBoxes();
        }

        private void LoadComboBoxes()
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
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('стелеві карнизи', 'настінні карнизи') ", conn);
                SqlDataReader sql1 = query.ExecuteReader(), sql2, sql3;
                while (sql1.Read())
                {
                    ListCornices.Add(sql1["name_g"].ToString().Trim(' '));
                }
                sql1.Close();
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('тюль', 'портьєрні', 'водовідштовхувальні', 'рулонні', 'жалюзі')", conn);
                sql2 = query.ExecuteReader();
                while (sql2.Read())
                {
                    ListCurtains.Add(sql2["name_g"].ToString().Trim(' '));
                }
                sql2.Close();
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('китиці', 'бахрома', 'люверси', 'тесьма')", conn);
                sql3 = query.ExecuteReader();
                while (sql3.Read())
                {
                    ListAccs.Add(sql3["name_g"].ToString().Trim(' '));
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


        public RelayCommand<object> AddContractorGoods
        {
            get => addContractorGoods ?? (addContractorGoods = new RelayCommand<object>(AddImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return (!string.IsNullOrWhiteSpace(NameAccessories) ||
                   !string.IsNullOrWhiteSpace(NameCurtain) ||
                   !string.IsNullOrWhiteSpace(NameCornice)) &&
                   !string.IsNullOrWhiteSpace(NameContractor) &&
                   ((!string.IsNullOrWhiteSpace(CornPrice.ToString()) && CornPrice > 0) ||
                   (!string.IsNullOrWhiteSpace(CurtPrice.ToString()) && CurtPrice > 0) ||
                   (!string.IsNullOrWhiteSpace(AccPrice.ToString()) && AccPrice > 0));
        }

        private void AddImpl(object obj)
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
            NavigationManager.Instance.Navigate(ViewType.Admin);
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
