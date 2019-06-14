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
    internal class OrderViewModel
    {

        private RelayCommand<Window> _addOrder;
        public ObservableCollection<string> ListCustomers { get; }
        public ObservableCollection<string> ListWorkshops { get; }
        public ObservableCollection<string> ListCornices { get; }


        private DateTime _dateOrd = DateTime.Now;
        private string _id;
        private string _codeWorkshop;
        private string _ipn;

        public OrderViewModel()
        {
            ListWorkshops = new ObservableCollection<string>(StationManager.DataStorage.ListNameWorkshops());
            ListCustomers = new ObservableCollection<string>(StationManager.DataStorage.ListCustomers());
            ListCornices = new ObservableCollection<string>(StationManager.DataStorage.ListCorniceInstallers());
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

       
        public RelayCommand<Window> AddOrder => _addOrder ?? (_addOrder = new RelayCommand<Window>(AddOrderImplementation, CanExecute));


        private bool CanExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(ID) && DateOrd <= DateTime.Now; 
        }

        private void AddOrderImplementation(Window obj)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);
            try
            {
                string code = null, ipn = null, id = "";
                SqlCommand query;
                conn.Open();

                if (CodeWorkshop!=null)
                {
                   query  = new SqlCommand("SELECT Code_workshop FROM Workshop WHERE name_shop like '" + CodeWorkshop + "%'", conn);
                   var reader = query.ExecuteReader();

                    while (reader.Read())
                    {
                        code = reader["Code_workshop"].ToString();
                    }
                    reader.Close();
                }
                query = new SqlCommand("Select ID FROM Customer WHERE last_name like '" + ID.Split(' ')[1]+"%'", conn);
                var reader1 = query.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString();
                }
                reader1.Close();
                if (Ipn!=null)
                {
                    query = new SqlCommand("SELECT Ipn FROM Cornices WHERE last_name like '" + Ipn.Split(' ')[1] + "%'", conn);
                    var reader2 = query.ExecuteReader();
                    while (reader2.Read())
                    {
                        ipn = reader2["Ipn"].ToString();
                    }
                    reader2.Close();
                }
                StationManager.CurrentOrder = new Order((++StationManager.NumOrder).ToString(), DateOrd, id, code, ipn);
                StationManager.DataStorage.AddOrder(StationManager.CurrentOrder);
                
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message  + "\n" + exc.Source + "\n"+ exc.StackTrace);
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
