using System;
using System.Collections.ObjectModel;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System.Windows;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace ais.ViewModels.UpdatingRowsVM
{
    class UpdOrderVM
    {
        private RelayCommand<Window> _updateOrder;

        private string _id;
        private string _codeWorkshop = "";
        private string _ipn = "";

        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        public UpdOrderVM()
        {
            LoadComboBoxes();
        }

        public Order CurrentOrder { get; } = StationManager.CurrentOrder;
        public ObservableCollection<string> ListWorkshops { get; } = new ObservableCollection<string>();
        public ObservableCollection<string> ListCornices { get; } = new ObservableCollection<string>();

        public RelayCommand<Window> UpdateOrder
        {
            get => _updateOrder ?? (_updateOrder = new RelayCommand<Window>(UpdImpl, CanUpd));
        }

        private bool CanUpd(Window obj)
        {
            return CurrentOrder.DateOrd <= DateTime.Now;
        }

        private void UpdImpl(Window obj)
        {
            string code = null, ipn = null;
            SqlCommand query;
            if (_conn == null)
            {
                throw new Exception("Connection String is Null");
            }
            _conn.Open();

            if (!CodeWorkshop.Equals(""))
            {
                query = new SqlCommand("SELECT Code_workshop FROM Workshop WHERE name_shop like '" + CodeWorkshop + "%'", _conn);
                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    code = reader["Code_workshop"].ToString();
                }
                reader.Close();
            }
            
            if (!Ipn.Equals(""))
            {
                query = new SqlCommand("SELECT Ipn FROM Cornices WHERE last_name like '" + Ipn.Split(' ')[1] + "%'", _conn);
                var reader2 = query.ExecuteReader();
                while (reader2.Read())
                {
                    ipn = reader2["Ipn"].ToString();
                }
                reader2.Close();
            }
            CurrentOrder.CodeWorkshop = code;
            CurrentOrder.Ipn = ipn;
            StationManager.DataStorage.UpdateOrder(StationManager.CurrentOrder, CurrentOrder);
            StationManager.CurrentOrder = CurrentOrder;
            obj.Close();
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
            try
            {
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();

                SqlCommand query = new SqlCommand("SELECT name_shop FROM Workshop", _conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    ListWorkshops.Add(select["name_shop"].ToString().Trim(' '));
                }
                select.Close();

               

                SqlCommand query2 = new SqlCommand("SELECT last_name, name_c FROM Cornices", _conn);
                SqlDataReader select2 = query2.ExecuteReader();
                while (select2.Read())
                {
                    ListCornices.Add(select2["name_c"].ToString().Trim(' ') + " " + select2["last_name"].ToString().Trim(' '));
                }
                select2.Close();

                //id, ipn, code

                SqlCommand query1 = new SqlCommand("SELECT last_name, name_cust FROM Customer WHERE ID = '" + CurrentOrder.ID + "'", _conn);
                SqlDataReader select1 = query1.ExecuteReader();
                while (select1.Read())
                {
                    ID = select1["name_cust"].ToString().Trim(' ') + " " + select1["last_name"].ToString().Trim(' ');
                }
                select1.Close();

                SqlCommand query3 = new SqlCommand("SELECT name_shop FROM Workshop WHERE Code_workshop = '" + CurrentOrder.CodeWorkshop + "'", _conn);
                SqlDataReader select3 = query3.ExecuteReader();
                while (select3.Read())
                {
                    if (select3["name_shop"] == DBNull.Value)
                        CodeWorkshop = "";
                    CodeWorkshop = select3["name_shop"].ToString().Trim(' ');
                }
                select3.Close();

                SqlCommand query4 = new SqlCommand("SELECT last_name, name_c FROM Cornices WHERE Ipn = '" + CurrentOrder.Ipn + "'", _conn);
                SqlDataReader select4 = query4.ExecuteReader();
                while (select4.Read())
                {
                    if (select4["name_c"] == DBNull.Value)
                        Ipn = "";
                    Ipn = select4["name_c"].ToString().Trim(' ') + " " + select4["last_name"].ToString().Trim(' ');
                }
                select4.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                _conn?.Close();
            }
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
