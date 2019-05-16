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
        private string nameGoods;
        private int quantityGoods;

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

                SqlCommand query = new SqlCommand("SELECT name_g FROM Goods", conn);
                SqlDataReader select = query.ExecuteReader(), select1;
                while (select.Read())
                {
                    ListGoods.Add(select["name_g"].ToString().Trim(' '));
                }
                select.Close();
                query = new SqlCommand("Select Num_ord FROM [Order]", conn);
                select1 = query.ExecuteReader();
                while(select1.Read())
                {
                    ListNums.Add(select1["Num_ord"].ToString().Trim(' '));
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
        }

        public ObservableCollection<string> ListGoods { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListNums { get; } = new ObservableCollection<string>();

        public string NumOrd
        {
            get => numOrd;
            set
            {
                numOrd = value;
                OnPropertyChanged();
            }
        }
        public string NameGoods
        {
            get => nameGoods;
            set
            {
                nameGoods = value;
                OnPropertyChanged();
            }
        }
        public int QuantityGoods
        {
            get => quantityGoods;
            set
            {
                quantityGoods = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> AddOrderGoods
        {
            get => addOrderGoods ?? (addOrderGoods=new RelayCommand<object>(AddImpl, CanAdd));
        }

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(NumOrd) &&
                   !string.IsNullOrWhiteSpace(NameGoods) &&
                   !string.IsNullOrWhiteSpace(QuantityGoods.ToString()) && 
                   QuantityGoods != 0;
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

                query = new SqlCommand("SELECT Articul FROM Goods WHERE name_g = '" + NameGoods + "'", conn);
                reader = query.ExecuteReader();

                while (reader.Read())
                {
                    articul = reader["Articul"].ToString();
                }
                reader.Close();

                StationManager.CurrentOrderGoods= new Order_Goods(NumOrd, articul, QuantityGoods);
                StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
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


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
