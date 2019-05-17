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
    class OrderGoodsViewModel
    {
        private string numOrd;
        private string nameCurtain;
        private string nameCornice;
        private string nameAccessories;
        private int curtAmount;
        private int cornAmount;
        private int accAmount;

        private RelayCommand<object> addOrderGoods;
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public OrderGoodsViewModel()
        {
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                //cornices
                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('стелеві карнизи', 'настінні карнизи') ", conn);
                SqlDataReader select = query.ExecuteReader(), sql1, sql2, sql3;
                while (select.Read())
                {
                    ListCornices.Add(select["name_g"].ToString().Trim(' '));
                }
                select.Close();
                //curtains
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('тюль', 'портьєрні', 'водовідштовхувальні', 'рулонні', 'жалюзі')", conn);
                sql1 = query.ExecuteReader();
                while (sql1.Read())
                {
                    ListCurtains.Add(sql1["name_g"].ToString().Trim(' '));
                }
                sql1.Close();
                //Accessories
                query = new SqlCommand("SELECT name_g FROM Goods WHERE type IN ('китиці', 'бахрома', 'люверси', 'тесьма')", conn);
                sql2 = query.ExecuteReader();
                while (sql2.Read())
                {
                    ListAccs.Add(sql2["name_g"].ToString().Trim(' '));
                }
                sql2.Close();
                //orders
                query = new SqlCommand("Select Num_ord FROM [Order]", conn);
                sql3 = query.ExecuteReader();
                while (sql3.Read())
                {
                    ListNums.Add(sql3["Num_ord"].ToString().Trim(' '));
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
        
        public ObservableCollection<string> ListNums { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCurtains { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCornices { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListAccs { get; } = new ObservableCollection<string>();

        public string NumOrd
        {
            get => /*StationManager.CurrentOrder.NumOrd ??*/ numOrd;
            set
            {
                numOrd = value;
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
            set
            {
                curtAmount = value;
                OnPropertyChanged();
            }
        }
        public int CornAmount
        {
            get => cornAmount;
            set
            {
                cornAmount = value;
                OnPropertyChanged();
            }
        }
        public int AccAmount
        {
            get => accAmount;
            set
            {
                accAmount = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> AddOrderGoods
        {
            get => addOrderGoods ?? (addOrderGoods = new RelayCommand<object>(AddImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(NumOrd) &&
                   !string.IsNullOrWhiteSpace(NameCurtain) &&
                   (!string.IsNullOrWhiteSpace(NameCornice) ||
                   !string.IsNullOrWhiteSpace(NameAccessories)) &&
                   !string.IsNullOrWhiteSpace(CurtAmount.ToString()) && CurtAmount > 0 &&
                   (!string.IsNullOrWhiteSpace(CornAmount.ToString()) ||
                   !string.IsNullOrWhiteSpace(AccAmount.ToString()));
        }

        private void AddImpl(object obj)
        {
            try
            {
                string articul = null;
                SqlDataReader reader1, reader2, reader3;
                SqlCommand query1, query2, query3;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                //curtain
                query1 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameCurtain + "'", conn);
                reader1 = query1.ExecuteReader();
                while (reader1.Read())
                {
                    articul = reader1["Articul"].ToString();
                }
                reader1.Close();
                StationManager.CurrentOrderGoods= new Order_Goods(NumOrd, articul, CurtAmount);
                StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
                MessageBox.Show("row added");
                //cornice
                if (!string.IsNullOrWhiteSpace(NameCornice))
                {
                    query2 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameCornice + "'", conn);
                    reader2 = query2.ExecuteReader();

                    while (reader2.Read())
                    {
                        articul = reader2["Articul"].ToString();
                    }
                    reader2.Close();
                    StationManager.CurrentOrderGoods = new Order_Goods(NumOrd, articul, CornAmount);
                    StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
                    MessageBox.Show("row added");
                }
                //accessories 
                if (!string.IsNullOrWhiteSpace(NameAccessories))
                {
                    query3 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameAccessories + "'", conn);
                    reader3 = query3.ExecuteReader();

                    while (reader3.Read())
                    {
                        articul = reader3["Articul"].ToString();
                    }
                    reader3.Close();
                    StationManager.CurrentOrderGoods = new Order_Goods(NumOrd, articul, AccAmount);
                    StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
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


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
