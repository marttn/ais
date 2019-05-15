using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;

namespace ais.ViewModels
{
    class AdminViewModel
    {
        private string _name;
        private string _lastName;
        private string _login;
        private string _type;
        private object _selectedRow;

        private ObservableCollection<object> _table/* = new ObservableCollection<object>()*/;

        private RelayCommand<object> _showTable;
        private RelayCommand<object> _closeCommand;
        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _deleteCommand;

        public Users CurrentUser { get; } = StationManager.CurrentUser;

        public AdminViewModel()
        {
            Name = CurrentUser.Name;
            LastName = CurrentUser.LastName;
            Login = CurrentUser.Login;
            Type = CurrentUser.Type;
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => $"@{_login}";
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public object SelectedRow
        {
            get => _selectedRow;
            set
            {
                _selectedRow = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<object> Table
        {
            get => _table;
            set
            {
                _table = value;
                OnPropertyChanged("Table");
            }
}

        public RelayCommand<object> CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation));
            }
        }

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }

        public RelayCommand<object> ShowTable
        {
            get
            {
                return _showTable ?? (_showTable = new RelayCommand<object>(ShowTableImplementation));
            }
        }

       
        private void ShowTableImplementation(object obj)
        {
            StationManager.CurrentTableType = $"{obj}";
           
            if (obj.Equals("Customer"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                }
                else if (obj.Equals("Cust_Tel"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                }
                else if (obj.Equals("Cornices"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                }
                else if (obj.Equals("Workshop"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                }
                else if (obj.Equals("Order"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                }
                else if (obj.Equals("Contractor"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                }
                else if (obj.Equals("Contractor_Tel"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                }
                else if (obj.Equals("Goods"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                }
                else if (obj.Equals("Contractor_Goods"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                }
                else if (obj.Equals("Order_Goods"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                }
                else if (obj.Equals("Contract"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                }
                else if (obj.Equals("Contract_Goods"))
                {
                Table = new ObservableCollection<object>(StationManager.DataStorage.ContractGoodsList);
                }
            
           // MessageBox.Show(Table.GetType().ToString());
            
        }

        public RelayCommand<object> AddCommand => _addCommand ?? (_addCommand = new RelayCommand<object>(AddRowImplementation));

        public RelayCommand<object> DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(DeleteRowImplementation, CanDeleteRow));

        private bool CanDeleteRow(object obj) => SelectedRow != null;

        private void DeleteRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    StationManager.CurrentOrder = (Order)SelectedRow;
                    StationManager.DataStorage.RemoveOrder(StationManager.CurrentOrder);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                    SelectedRow = null;
                    break;
                case "Customer":
                    StationManager.CurrentCustomer = (Customer)SelectedRow;
                    StationManager.DataStorage.RemoveCustomer(StationManager.CurrentCustomer);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                    SelectedRow = null;
                    break;
            }
        }

        private void AddRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
              case "Order":
                    NavigationManager.Instance.Navigate(ViewType.NewOrder);
                    //Table.Add(StationManager.CurrentOrder);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                    break;
                case "Customer":
                    NavigationManager.Instance.Navigate(ViewType.NewCustomer);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                    break;
                case "Cust_Tel":
                    break;
                case "Cornices":
                    break;
                case "Workshop":
                    break;
                case "Contractor":
                    break;
                case "Contractor_Tel":
                    break;
                case "Goods":
                    break;
                case "Contractor_Goods":
                    break;
                case "Order_Goods":
                    break;
                case "Contract":
                    break;
                case "Contract_Goods":
                    break;
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
