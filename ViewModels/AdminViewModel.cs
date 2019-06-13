using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ais.Views;
using ais.Views.AddingRows;
using ais.Views.UpdatingRows;

namespace ais.ViewModels
{
    class AdminViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _lastName;
        private string _login;
        private string _type;
        private object _selectedRow;

        private string _selectedTable;

        private DateTime _startDate;
        private DateTime _endDate;

        private ObservableCollection<object> _table;

        private Users _selectedUser;

        private RelayCommand<object> _showTable;

        private RelayCommand<object> _closeCommand;
        private RelayCommand<object> _homeCommand;

        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _updateCommand;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _costsCommand;
        private RelayCommand<object> _printCommand;

        private RelayCommand<object> _addUserCommand;
        private RelayCommand<object> _deleteUserCommand;
        
        public Users CurrentUser { get; } = StationManager.CurrentUser;
        public ObservableCollection<Users> UsersCollection { get; } = new ObservableCollection<Users>(StationManager.DataStorage.UsersList);

        public ObservableCollection<string> ListTables { get; } = new ObservableCollection<string>
        {
            "Customer", "Cust_Tel", "Cornices", "Workshop", "Order", "Contractor", "Contractor_Tel", "Goods",
            "Contractor_Goods", "Order_Goods", "Contract", "Contract_Goods"
        };

        public Users SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }
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
                OnPropertyChanged("SelectedRow");
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged("StartDate");
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        public string SelectedTable
        {
            get => _selectedTable;
            set
            {
                _selectedTable = value;
                OnPropertyChanged("SelectedTable");
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

        public RelayCommand<object> CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(o=> StationManager.CloseApp()));
        public RelayCommand<object> HomeCommand => _homeCommand ?? (_homeCommand = new RelayCommand<object>(o=>NavigationManager.Instance.Navigate(ViewType.SignIn)));


        public RelayCommand<object> ShowTable => _showTable ?? (_showTable = new RelayCommand<object>(ShowTableImplementation));

        public RelayCommand<object> CostsCommand => _costsCommand ?? (_costsCommand = new RelayCommand<object>(ShowCosts, CanShow));

        public  RelayCommand<object> PrintCommand => _printCommand ??(_printCommand = new RelayCommand<object>(PrintImpl, CanPrint));

        private bool CanPrint(object obj)
        {
            return !string.IsNullOrWhiteSpace(SelectedTable);
        }

        private void PrintImpl(object obj)
        {
            Print print = new Print(SelectedTable);
            print.ShowDialog();
        }

        private bool CanShow(object obj)
        {
            return StartDate < EndDate;
        }

        private void ShowCosts(object obj)
        {
            Costs costs = new Costs(StartDate, EndDate);
            costs.ShowDialog();
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
                    UpdOrderView upd = new UpdOrderView();
                    upd.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                    SelectedRow = null;
                    break;
                case "Customer":
                    StationManager.CurrentCustomer = (Customer)SelectedRow;
                    UpdCustomerView updateCustomerView = new UpdCustomerView();
                    updateCustomerView.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                    SelectedRow = null;
                    break;
                case "Cust_Tel":
                    StationManager.CurrentCustTel = (Cust_Tel)SelectedRow;
                    UpdCustTel updCustTel = new UpdCustTel();
                    updCustTel.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                    SelectedRow = null;
                    break;
                case "Cornices":
                    StationManager.CurrentCornices = (Cornices)SelectedRow;
                    UpdCornicesView updCornices = new UpdCornicesView();
                    updCornices.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                    SelectedRow = null;
                    break;
                case "Workshop":
                    StationManager.CurrentWorkshop = (Workshop)SelectedRow;
                    UpdWorkshopView updWorkshop = new UpdWorkshopView();
                    updWorkshop.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                    SelectedRow = null;
                    break;
                case "Contractor":
                    StationManager.CurrentContractor= (Contractor)SelectedRow;
                    UpdContractorView updContractor = new UpdContractorView();
                    updContractor.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                    SelectedRow = null;
                    break;
                case "Contractor_Tel":
                    StationManager.CurrentContractorTel = (Contractor_Tel)SelectedRow;
                    UpdContractorTel tel = new UpdContractorTel();
                    tel.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                    SelectedRow = null;
                    break;
                case "Goods":
                    StationManager.CurrentGoods = (Goods)SelectedRow;
                    UpdGoodsView updGoods = new UpdGoodsView();
                    updGoods.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                    SelectedRow = null;
                    break;
                case "Contractor_Goods":
                    StationManager.CurrentContractorGoods = (Contractor_Goods)SelectedRow;
                    UpdContractorGoodsView updContractorGoods = new UpdContractorGoodsView();
                    updContractorGoods.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                    SelectedRow = null;
                    break;
                case "Order_Goods":
                    StationManager.CurrentOrderGoods = (Order_Goods)SelectedRow;
                    UpdOrderGoodsView orderGoods = new UpdOrderGoodsView();
                    orderGoods.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                    SelectedRow = null;
                    break;
                case "Contract":
                    StationManager.CurrentContract = (Contract)SelectedRow;
                    UpdContractView contract = new UpdContractView();
                    contract.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                    SelectedRow = null;
                    break;
                case "Contract_Goods":
                    StationManager.CurrentContractGoods = (Contract_Goods)SelectedRow;
                    UpdContractGoodsView contractGoods = new UpdContractGoodsView();
                    contractGoods.ShowDialog();
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
                    NewOrderView order = new NewOrderView();
                    order.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrdersList);
                    OnPropertyChanged("Table");
                    break;
                case "Customer":
                    NewCustomerView customer = new NewCustomerView();
                    customer.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustomersList);
                    break;
                case "Cust_Tel":
                    SelectCustTel select = new SelectCustTel();
                    select.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CustTelsList);
                    break;
                case "Cornices":
                    NewCornicesView cornices = new NewCornicesView();
                    cornices.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.CornicesList);
                    break;
                case "Workshop":
                    NewWorkshopView workshop = new NewWorkshopView();
                    workshop.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.WorkshopsList);
                    break;
                case "Contractor":
                    NewContractorView contractor = new NewContractorView();
                    contractor.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorsList);
                    break;
                case "Contractor_Tel":
                    SelectContractorTel tel = new SelectContractorTel();
                    tel.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorTelList);
                    break;
                case "Goods":
                    NewGoodsView goods = new NewGoodsView();
                    goods.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.GoodsList);
                    break;
                case "Contractor_Goods":
                    NewContractorGoodsView contrgoods = new NewContractorGoodsView();
                    contrgoods.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractorGoodsList);
                    break;
                case "Order_Goods":
                    NewOrderGoodsView orderGoods = new NewOrderGoodsView();
                    orderGoods.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.OrderGoodsList);
                    break;
                case "Contract":
                    NewContractView contract = new NewContractView();
                    contract.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractsList);
                    break;
                case "Contract_Goods":
                    NewContractGoodsView view = new NewContractGoodsView();
                    view.ShowDialog();
                    Table = new ObservableCollection<object>(StationManager.DataStorage.ContractGoodsList);
                    break;
            }
        }


        public RelayCommand<object> AddUserCommand => _addUserCommand ?? (_addUserCommand =
                                                          new RelayCommand<object>(
                                                              o => NavigationManager.Instance.Navigate(
                                                                  viewType: ViewType.SignUp)));

        public RelayCommand<object> DeleteUserCommand => _deleteUserCommand ?? (_deleteUserCommand =
                                                             new RelayCommand<object>(
                                                                 o => StationManager.DataStorage.DeleteUser(
                                                                     StationManager.CurrentUser),
                                                                 o => SelectedUser != null));
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
