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
    class CustTelViewModel
    {
        private string name;
        private string tel;
        private string selectedName;
        private RelayCommand<object> addTel;
        private RelayCommand<object> addSelTel;
        

        public CustTelViewModel()
        {
            
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                SqlCommand query1 = new SqlCommand("SELECT last_name, name_cust FROM Customer", conn);
                SqlDataReader select1 = query1.ExecuteReader();
                while (select1.Read())
                {
                    CustomersList.Add(select1["name_cust"].ToString().Trim(' ') + " " + select1["last_name"].ToString().Trim(' '));
                }
                select1.Close();
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

        public ObservableCollection<string> CustomersList { get; } = new ObservableCollection<string>();
        SqlConnection conn = new SqlConnection(Properties.Settings.Default.ais);

        public string Name
        {
            get => name ?? (name = $"{StationManager.CurrentCustomer.Name} {StationManager.CurrentCustomer.LastName}");
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Tel
        {
            get => tel;
            set
            {
                tel = value;
                OnPropertyChanged();
            }
        }

        public string SelectedName
        {
            get => selectedName;
            set
            {
                selectedName = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<object> AddTel
        {
            get => addTel ?? (addTel = new RelayCommand<object>(AddTelImpl, CanAdd));
        }
        public RelayCommand<object> AddSelTel
        {
            get => addSelTel ?? (addSelTel = new RelayCommand<object>(AddSelected, CanAddSelected));
        }

        private bool CanAddSelected(object obj)
        {
            return !string.IsNullOrWhiteSpace(Tel) && (Tel.Length == 10)
                && !string.IsNullOrWhiteSpace(SelectedName);
        }

        private void AddSelected(object obj)
        {
            
            try
            {
                string id = "";
                SqlDataReader reader1;
                SqlCommand query;
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                
                query = new SqlCommand("Select ID FROM Customer WHERE last_name = '" + SelectedName.Split(' ')[1] + "'", conn);
                reader1 = query.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString();
                }
                reader1.Close();
                StationManager.CurrentCustTel = new Cust_Tel(Tel, id);
                StationManager.DataStorage.AddCustTel(StationManager.CurrentCustTel);
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

        private void AddTelImpl(object obj)
        {
            
            try
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                conn.Open();
                string id = "";
                SqlCommand query = new SqlCommand("SELECT ID FROM Customer WHERE name_cust = '" + Name.Split(' ')[0] + "' and last_name = '" + Name.Split(' ')[1] + "'", conn);
                SqlDataReader select = query.ExecuteReader();
                while (select.Read())
                {
                    id = select["ID"].ToString();
                }
                select.Close();
                StationManager.CurrentCustTel = new Cust_Tel(Tel, id);
                StationManager.DataStorage.AddCustTel(StationManager.CurrentCustTel);
                
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
            return !string.IsNullOrWhiteSpace(Tel) && (Tel.Length == 10);
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
