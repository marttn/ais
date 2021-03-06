﻿using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace ais.ViewModels.AddingRowsVM
{
    class CustTelViewModel
    {
        private string _name;
        private string _tel;
        private string _selectedName;
        private RelayCommand<Window> _addTel;
        private RelayCommand<Window> _addSelTel;
        public ObservableCollection<string> CustomersList { get; }
        readonly SqlConnection _conn = new SqlConnection(Properties.Settings.Default.ais);

        public CustTelViewModel()
        {
            CustomersList = new ObservableCollection<string>(StationManager.DataStorage.ListCustomers());
        }

        
        public string Name
        {
            get => _name ?? (_name = $"{StationManager.CurrentCustomer.Name.Trim(' ')} {StationManager.CurrentCustomer.LastName.Trim(' ')}");
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Tel
        {
            get => _tel;
            set
            {
                _tel = value;
                OnPropertyChanged();
            }
        }

        public string SelectedName
        {
            get => _selectedName;
            set
            {
                _selectedName = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand<Window> AddTel => _addTel ?? (_addTel = new RelayCommand<Window>(AddTelImpl, CanAdd));

        public RelayCommand<Window> AddSelTel => _addSelTel ?? (_addSelTel = new RelayCommand<Window>(AddSelected, CanAddSelected));

        private bool CanAddSelected(object obj)
        {
            if (Tel != null)
                return new Regex("\\d{10}").IsMatch(Tel) && !string.IsNullOrWhiteSpace(SelectedName);
            return false;
        }

        private void AddSelected(Window obj)
        {
            
            try
            {
                string id = "";
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();
                
                var query = new SqlCommand("Select ID FROM Customer WHERE last_name = '" + SelectedName.Split(' ')[1] + "'", _conn);
                var reader1 = query.ExecuteReader();
                while (reader1.Read())
                {
                    id = reader1["ID"].ToString();
                }
                reader1.Close();
                StationManager.CurrentCustTel = new Cust_Tel(Tel, id);
                StationManager.DataStorage.AddCustTel(StationManager.CurrentCustTel);
                

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

        private void AddTelImpl(Window obj)
        {
            
            try
            {
                if (_conn == null)
                {
                    throw new Exception("Connection String is Null");
                }
                _conn.Open();
                string id = "";
                SqlCommand query = new SqlCommand("SELECT ID FROM Customer WHERE name_cust like '" + Name.Split(' ')[0] + "%' and last_name like '" + Name.Split(' ')[1] + "%'", _conn);
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
                _conn?.Close();
            }
            obj.Close();
        }

        private bool CanAdd(object obj)
        {
            if (Tel != null)
                return new Regex("\\d{10}").IsMatch(Tel);
            return false;
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
