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
    class OrderGoodsViewModel
    {
        private string _numOrd;
        private string _nameCurtain;
        private string _nameCornice;
        private string _nameAccessories;
        private int _curtAmount;
        private int _cornAmount;
        private int _accAmount;

        private RelayCommand<Window> _addOrderGoods;
        private RelayCommand<Window> _addOrderDetails;
        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        public OrderGoodsViewModel()
        {
                //cornices
                ListCornices = new ObservableCollection<string>(StationManager.DataStorage.ListCornices());
                //curtains
                ListCurtains = new ObservableCollection<string>(StationManager.DataStorage.ListCurtains());
                //Accessories
                ListAccs = new ObservableCollection<string>(StationManager.DataStorage.ListAccs());
                //orders
                ListNums = new ObservableCollection<string>(StationManager.DataStorage.ListOrderNums());
            
        }
        
        public ObservableCollection<string> ListNums { get; }
        public ObservableCollection<string> ListCurtains { get; }
        public ObservableCollection<string> ListCornices { get; }
        public ObservableCollection<string> ListAccs { get; }

        public string NumOrd
        {
            get => /*StationManager.CurrentOrder.NumOrd ??*/ _numOrd;
            set
            {
                _numOrd = value;
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
            set
            {
                _curtAmount = value;
                OnPropertyChanged();
            }
        }
        public int CornAmount
        {
            get => _cornAmount;
            set
            {
                _cornAmount = value;
                OnPropertyChanged();
            }
        }
        public int AccAmount
        {
            get => _accAmount;
            set
            {
                _accAmount = value;
                OnPropertyChanged();
            }
        }

        public string OrderDetails { get; set; } =
            $"Number of order: {StationManager.CurrentOrder.NumOrd.Trim(' ')}, date: {StationManager.CurrentOrder.DateOrd.ToShortDateString()}";

        public RelayCommand<Window> AddOrderGoods => _addOrderGoods ?? (_addOrderGoods = new RelayCommand<Window>(AddImpl, CanAdd));

        private bool CanAdd(object obj)
        {
            return !string.IsNullOrWhiteSpace(NumOrd) &&
                   !string.IsNullOrWhiteSpace(NameCurtain) && !string.IsNullOrWhiteSpace(CurtAmount.ToString()) &&
                   CurtAmount > 0 |
                   (!string.IsNullOrWhiteSpace(NameCornice) && !string.IsNullOrWhiteSpace(CornAmount.ToString()) &&
                    CornAmount > 0) |
                   (!string.IsNullOrWhiteSpace(NameAccessories) && !string.IsNullOrWhiteSpace(AccAmount.ToString()) &&
                    AccAmount > 0);
        }

        private void AddImpl(Window obj)
        {
            try
            {
                string articul = null;
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();
                //curtain
                var query1 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '" + NameCurtain + "%'", _conn);
                var reader1 = query1.ExecuteReader();
                while (reader1.Read())
                {
                    articul = reader1["Articul"].ToString();
                }
                reader1.Close();
                if (StationManager.DataStorage.OrderGoodsList.Exists(u => u.NumOrd.Trim(' ').Equals(NumOrd) &&
                u.Articul.Trim(' ').Equals(articul)))
                {
                    MessageBox.Show("Item "+ NameCurtain+" is already added in order №" + NumOrd);
                }
                else
                {
                    StationManager.CurrentOrderGoods = new Order_Goods(NumOrd, articul, CurtAmount);
                    StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
                    
                }
                //cornice
                if (!string.IsNullOrWhiteSpace(NameCornice))
                {
                    var query2 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '" + NameCornice + "%'", _conn);
                    var reader2 = query2.ExecuteReader();

                    while (reader2.Read())
                    {
                        articul = reader2["Articul"].ToString();
                    }
                    reader2.Close();
                    if (StationManager.DataStorage.OrderGoodsList.Exists(u => u.NumOrd.Trim(' ').Equals(NumOrd) &&
                        u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Item " + NameCornice + " is already added in order №" + NumOrd);
                    }
                    else
                    {
                        StationManager.CurrentOrderGoods = new Order_Goods(NumOrd, articul, CornAmount);
                        StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
                        
                    }
                }
                //accessories 
                if (!string.IsNullOrWhiteSpace(NameAccessories))
                {
                    var query3 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '" + NameAccessories + "%'", _conn);
                    var reader3 = query3.ExecuteReader();

                    while (reader3.Read())
                    {
                        articul = reader3["Articul"].ToString();
                    }
                    reader3.Close();
                    if (StationManager.DataStorage.OrderGoodsList.Exists(u => u.NumOrd.Trim(' ').Equals(NumOrd) &&
                     u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Item " + NameAccessories + " is already added in order №" + NumOrd);
                    }
                    else
                    {
                        StationManager.CurrentOrderGoods = new Order_Goods(NumOrd, articul, AccAmount);
                        StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);
                        
                    }
                }

                StationManager.DataStorage.UpdateOrdersList();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                _conn?.Close();
            }
            obj.Close();
        }

        public RelayCommand<Window> AddOrderDetails =>
            _addOrderDetails ?? (_addOrderDetails = new RelayCommand<Window>(AddDetails, CanAddDetails));

        private bool CanAddDetails(Window obj)
        {
            return !string.IsNullOrWhiteSpace(NameCurtain) && !string.IsNullOrWhiteSpace(CurtAmount.ToString()) &&
                   CurtAmount > 0 |
                   (!string.IsNullOrWhiteSpace(NameCornice) && !string.IsNullOrWhiteSpace(CornAmount.ToString()) &&
                    CornAmount > 0) |
                   (!string.IsNullOrWhiteSpace(NameAccessories) && !string.IsNullOrWhiteSpace(AccAmount.ToString()) &&
                    AccAmount > 0);
        }

        private void AddDetails(Window obj)
        {
            try
            {
                string articul = null, num = OrderDetails.Remove(19).Replace("Number of order: ", "");
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();

                //curtain
                var query1 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '" + NameCurtain + "%'", _conn);
                var reader1 = query1.ExecuteReader();
                while (reader1.Read())
                {
                    articul = reader1["Articul"].ToString();
                }
                reader1.Close();
                if (StationManager.DataStorage.OrderGoodsList.Exists(u => u.NumOrd.Trim(' ').Equals(num) &&
                u.Articul.Trim(' ').Equals(articul)))
                {
                    MessageBox.Show("Item " + NameCurtain + " is already added in order №" + num);
                }
                else
                {
                    StationManager.CurrentOrderGoods = new Order_Goods(num, articul, CurtAmount);
                    StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);

                }
                //cornice
                if (!string.IsNullOrWhiteSpace(NameCornice))
                {
                    var query2 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '" + NameCornice + "%'", _conn);
                    var reader2 = query2.ExecuteReader();

                    while (reader2.Read())
                    {
                        articul = reader2["Articul"].ToString();
                    }
                    reader2.Close();
                    if (StationManager.DataStorage.OrderGoodsList.Exists(u => u.NumOrd.Trim(' ').Equals(num) &&
                        u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Item " + NameCornice + " is already added in order №" + num);
                    }
                    else
                    {
                        StationManager.CurrentOrderGoods = new Order_Goods(num, articul, CornAmount);
                        StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);

                    }
                }
                //accessories 
                if (!string.IsNullOrWhiteSpace(NameAccessories))
                {
                    var query3 = new SqlCommand("SELECT Articul FROM Goods WHERE name_g like '" + NameAccessories + "%'", _conn);
                    var reader3 = query3.ExecuteReader();

                    while (reader3.Read())
                    {
                        articul = reader3["Articul"].ToString();
                    }
                    reader3.Close();
                    if (StationManager.DataStorage.OrderGoodsList.Exists(u => u.NumOrd.Trim(' ').Equals(num) &&
                     u.Articul.Trim(' ').Equals(articul)))
                    {
                        MessageBox.Show("Item " + NameAccessories + " is already added in order №" + num);
                    }
                    else
                    {
                        StationManager.CurrentOrderGoods = new Order_Goods(num, articul, AccAmount);
                        StationManager.DataStorage.AddOrderGoods(StationManager.CurrentOrderGoods);

                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                _conn.Close();
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
