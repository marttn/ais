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
    internal class OrderViewModel
    {
        //public Order CurrentOrder { get; }

        private RelayCommand<object> _addOrder;
        public ObservableCollection<string> ListCustomers { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListWorkshops { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCornices { get; } = new ObservableCollection<string>();


        private DateTime _dateOrd = DateTime.Now;
        private string _id;
        private string _codeWorkshop;
        private string _ipn;

        public OrderViewModel()
        {
            LoadComboBoxes();
        }
        public DateTime DateOrd
        {
            get => _dateOrd;
            set
            {
                _dateOrd = value;
                OnPropertyChanged();
            }
        }

        public string ID
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string CodeWorkshop
        {
            get => _codeWorkshop;
            set
            {
                _codeWorkshop = value;
                OnPropertyChanged();
            }
        }

        public string Ipn
        {
            get => _ipn;
            set
            {
                _ipn = value;
                OnPropertyChanged();
            }
        }

        private void LoadComboBoxes()
        {
            
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);
           // MessageBox.Show("start load");
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_shop FROM Workshop", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    ListWorkshops.Add(select["name_shop"].ToString().Trim(' '));
                }
                select.Close();
                SqlCommand query1 = new SqlCommand("SELECT last_name, name_cust FROM Customer", conn);
                SqlDataReader select1 = query1.ExecuteReader();
                while (select1.Read())
                {
                    ListCustomers.Add(select1["name_cust"].ToString().Trim(' ') + " " + select1["last_name"].ToString().Trim(' '));
                }
                select1.Close();
                SqlCommand query2 = new SqlCommand("SELECT last_name, name_c FROM Cornices", conn);
                SqlDataReader select2 = query2.ExecuteReader();
                while (select2.Read())
                {
                    ListCornices.Add(select2["name_c"].ToString().Trim(' ') + " " + select2["last_name"].ToString().Trim(' '));
                }
                select2.Close();
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

        




        public RelayCommand<object> AddOrder
        {
            get
            {
                return _addOrder ?? (_addOrder = new RelayCommand<object>(AddOrderImplementation, CanExecute));
            }
        }
        

        private bool CanExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(ID) && DateOrd <= DateTime.Now; 
        }

        private void AddOrderImplementation(object obj)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);
            try
            {
                string code = null, ipn = null, id = "";
                SqlDataReader reader, reader1, reader2;
                SqlCommand query;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();

                if (!CodeWorkshop.Equals(""))
                {
                   query  = new SqlCommand("SELECT Code_workshop FROM Workshop WHERE name_shop = '" + CodeWorkshop + "'", conn);
                   reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        code = reader["Code_workshop"].ToString();
                    }
                    reader.Close();
                }
                query = new SqlCommand("Select ID FROM Customer WHERE last_name = '" + ID.Split(' ')[1]+"'", conn);
                reader1 = query.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString();
                }
                reader1.Close();
                if (!Ipn.Equals(""))
                {
                    query = new SqlCommand("SELECT Ipn FROM Cornices WHERE last_name = '" + Ipn.Split(' ')[1] + "'", conn);
                    reader2 = query.ExecuteReader();
                    while (reader2.Read())
                    {
                        ipn = reader2["Ipn"].ToString();
                    }
                    reader2.Close();
                }
                StationManager.CurrentOrder = new Order((++StationManager.NumOrder).ToString(), DateOrd, id, code, ipn);
                StationManager.DataStorage.AddOrder(StationManager.CurrentOrder);
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
            ID = Ipn = CodeWorkshop = "";
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
