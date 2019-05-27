using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        private RelayCommand<object> _updateCommand;
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
            /*private */set
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

        public RelayCommand<object> UpdateCommand => _updateCommand ?? (_updateCommand = new RelayCommand<object>(UpdateRowImplementation, CanDeleteRow));

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
                case "Cust_Tel":
                    StationManager.CurrentCustTel = (Cust_Tel)SelectedRow;
                    StationManager.DataStorage.RemoveCustTel(StationManager.CurrentCustTel);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                    SelectedRow = null;
                    break;
                case "Cornices":
                    StationManager.CurrentCornices = (Cornices)SelectedRow;
                    StationManager.DataStorage.RemoveCornices(StationManager.CurrentCornices);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                    SelectedRow = null;
                    break;
                case "Workshop":
                    StationManager.CurrentWorkshop = (Workshop)SelectedRow;
                    StationManager.DataStorage.RemoveWorkshop(StationManager.CurrentWorkshop);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                    SelectedRow = null;
                    break;
                case "Contractor":
                    StationManager.CurrentContractor = (Contractor)SelectedRow;
                    StationManager.DataStorage.RemoveContractor(StationManager.CurrentContractor);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                    SelectedRow = null;
                    break;
                case "Contractor_Tel":
                    StationManager.CurrentContractorTel = (Contractor_Tel)SelectedRow;
                    StationManager.DataStorage.RemoveContractorTel(StationManager.CurrentContractorTel);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                    SelectedRow = null;
                    break;
                case "Goods":
                    StationManager.CurrentGoods = (Goods)SelectedRow;
                    StationManager.DataStorage.RemoveGoods(StationManager.CurrentGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                    SelectedRow = null;
                    break;
                case "Contractor_Goods":
                    StationManager.CurrentContractorGoods = (Contractor_Goods)SelectedRow;
                    StationManager.DataStorage.RemoveContractorGoods(StationManager.CurrentContractorGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                    SelectedRow = null;
                    break;
                case "Order_Goods":
                    StationManager.CurrentOrderGoods = (Order_Goods)SelectedRow;
                    StationManager.DataStorage.RemoveOrderGoods(StationManager.CurrentOrderGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                    SelectedRow = null;
                    break;
                case "Contract":
                    StationManager.CurrentContract = (Contract)SelectedRow;
                    StationManager.DataStorage.RemoveContract(StationManager.CurrentContract);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                    SelectedRow = null;
                    break;
                case "Contract_Goods":
                    StationManager.CurrentContractGoods = (Contract_Goods)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.NewContractGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractGoodsList);
                    SelectedRow = null;
                    break;
            }
            
        }

        private void UpdateRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    StationManager.CurrentOrder = (Order)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdOrder);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                    SelectedRow = null;
                    break;
                case "Customer":
                    StationManager.CurrentCustomer = (Customer)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdCustomer);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                    SelectedRow = null;
                    break;
                case "Cust_Tel":
                    StationManager.CurrentCustTel = (Cust_Tel)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdCustTel);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                    SelectedRow = null;
                    break;
                case "Cornices":
                    StationManager.CurrentCornices = (Cornices)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdCornices);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                    SelectedRow = null;
                    break;
                case "Workshop":
                    StationManager.CurrentWorkshop = (Workshop)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdWorkshop);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                    SelectedRow = null;
                    break;
                case "Contractor":
                    StationManager.CurrentContractor= (Contractor)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdContractor);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                    SelectedRow = null;
                    break;
                case "Contractor_Tel":
                    StationManager.CurrentContractorTel = (Contractor_Tel)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdContractorTel);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                    SelectedRow = null;
                    break;
                case "Goods":
                    StationManager.CurrentGoods = (Goods)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                    SelectedRow = null;
                    break;
                case "Contractor_Goods":
                    StationManager.CurrentContractorGoods = (Contractor_Goods)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdContractorGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                    SelectedRow = null;
                    break;
                case "Order_Goods":
                    StationManager.CurrentOrderGoods = (Order_Goods)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdOrderGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                    SelectedRow = null;
                    break;
                case "Contract":
                    StationManager.CurrentContract = (Contract)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdContract);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                    SelectedRow = null;
                    break;
                case "Contract_Goods":
                    StationManager.CurrentContractGoods = (Contract_Goods)SelectedRow;
                    NavigationManager.Instance.Navigate(ViewType.UpdContractGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractGoodsList);
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
                    NavigationManager.Instance.Navigate(ViewType.NewSelCustTel);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                    break;
                case "Cornices":
                    NavigationManager.Instance.Navigate(ViewType.NewCornices);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                    break;
                case "Workshop":
                    NavigationManager.Instance.Navigate(ViewType.NewWorkshop);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                    break;
                case "Contractor":
                    NavigationManager.Instance.Navigate(ViewType.NewContractor);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                    break;
                case "Contractor_Tel":
                    NavigationManager.Instance.Navigate(ViewType.NewSelContractorTel);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                    break;
                case "Goods":
                    NavigationManager.Instance.Navigate(ViewType.NewGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                    break;
                case "Contractor_Goods":
                    NavigationManager.Instance.Navigate(ViewType.NewContractorGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                    break;
                case "Order_Goods":
                    NavigationManager.Instance.Navigate(ViewType.NewOrderGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                    break;
                case "Contract":
                    NavigationManager.Instance.Navigate(ViewType.NewContract);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                    break;
                case "Contract_Goods":
                    NavigationManager.Instance.Navigate(ViewType.NewContractGoods);
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractGoodsList);
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
