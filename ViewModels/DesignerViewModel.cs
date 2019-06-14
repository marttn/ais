using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;
using ais.Views;
using ais.Views.AddingRows;
using ais.Views.UpdatingRows;

namespace ais.ViewModels
{
    internal class DesignerViewModel : INotifyPropertyChanged
    {
        private string _name;
        private string _lastName;
        private string _login;
        private string _type;
        private Order _selectedOrder;
        private Customer _selectedCustomer;
        private Cornices _selectedCornices;
        private Workshop _selectedWorkshop;

        private DateTime _startDate;
        private DateTime _endDate;


        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _updateCommand;
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _addGoodsCommand;

        private RelayCommand<object> _showOrders;
        private RelayCommand<object> _calcProfit;
        private RelayCommand<object> _showCustomers;
        private RelayCommand<object> _selectTable;

        private RelayCommand<object> _closeCommand;
        private RelayCommand<object> _homeCommand;

        private RelayCommand<object> _addNumCommand;

        private string _selectedPeriod;
        private string _selectedTable;
        private string _selectedSortOrder;

        private ObservableCollection<Order> _orders;
        private ObservableCollection<Customer> _сustomers;
        private ObservableCollection<Cornices> _cornices;
        private ObservableCollection<Workshop> _workshops;

        public Users CurrentUser { get; } = StationManager.CurrentUser;

        public DesignerViewModel()
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
        
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
            }
        }
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }
        public Cornices SelectedCornice
        {
            get => _selectedCornices;
            set
            {
                _selectedCornices = value;
                OnPropertyChanged();
            }
        }
        public Workshop SelectedWorkshop
        {
            get => _selectedWorkshop;
            set
            {
                _selectedWorkshop = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Order> Orders
        {
            get => new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Customer> Customers
        {
            get => new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
            set
            {
                _сustomers = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Cornices> Cornices
        {
            get => new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
            set
            {
                _cornices = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Workshop> Workshops
        {
            get => new ObservableCollection<Workshop>(StationManager.DataStorage.WorkshopsList);
            set
            {
                _workshops = value;
                OnPropertyChanged();
            }
        }
        


        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }

        public string SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged();
            }
        }
        public string SelectedTable
        {
            get => _selectedTable?.Replace("System.Windows.Controls.ComboBoxItem: ", "");
            set
            {
                _selectedTable = value;
                OnPropertyChanged();
            }
        }
        public string SelectedSortOrder
        {
            get => _selectedSortOrder;
            set
            {
                _selectedSortOrder = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand<object> AddCommand => _addCommand ?? (_addCommand = new RelayCommand<object>(AddRowImplementation));

        private void AddRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    NewOrderView order = new NewOrderView();
                    order.ShowDialog();
                    Orders = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
                    OnPropertyChanged("Orders");
                    break;
                case "Customer":
                    NewCustomerView customer = new NewCustomerView();
                    customer.ShowDialog();
                    Customers = new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
                    break;
                case "Cornices":
                    NewCornicesView cornices = new NewCornicesView();
                    cornices.ShowDialog();
                    Cornices = new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
                    OnPropertyChanged("Cornices");
                    break;
                case "Workshop":
                    NewWorkshopView workshop = new NewWorkshopView();
                    workshop.ShowDialog();
                    Workshops = new ObservableCollection<Workshop>(StationManager.DataStorage.WorkshopsList);
                    break;
                case null:
                    break;
            }
        }

        public RelayCommand<object> UpdateCommand => _updateCommand ?? (_updateCommand = new RelayCommand<object>(UpdateRowImplementation, CanDeleteRow));

        private bool CanDeleteRow(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    return SelectedOrder != null;
                case "Customer":
                    return SelectedCustomer != null;
                case "Cornices":
                    return SelectedCornice != null;
                case "Workshop":
                    return SelectedWorkshop != null;
            }

            return false;
        }

        private void UpdateRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    StationManager.CurrentOrder = SelectedOrder;
                    UpdOrderView upd = new UpdOrderView();
                    upd.ShowDialog();
                    Orders = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
                    SelectedOrder = null;
                    break;
                case "Customer":
                    StationManager.CurrentCustomer = SelectedCustomer;
                    UpdCustomerView updateCustomerView = new UpdCustomerView();
                    updateCustomerView.ShowDialog();
                    Customers = new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
                    SelectedCustomer = null;
                    break;
                case "Cornices":
                    StationManager.CurrentCornices = SelectedCornice;
                    UpdCornicesView updCornices = new UpdCornicesView();
                    updCornices.ShowDialog();
                    Cornices = new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
                    SelectedCornice = null;
                    break;
                case "Workshop":
                    StationManager.CurrentWorkshop = SelectedWorkshop;
                    UpdWorkshopView updWorkshop = new UpdWorkshopView();
                    updWorkshop.ShowDialog();
                    Workshops = new ObservableCollection<Workshop>(StationManager.DataStorage.WorkshopsList);
                    SelectedWorkshop = null;
                    break;
            }
        }

        public RelayCommand<object> DeleteCommand => _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(DeleteRowImplementation, CanDeleteRow));

        private void DeleteRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    StationManager.CurrentOrder = SelectedOrder;
                    StationManager.DataStorage.RemoveOrder(StationManager.CurrentOrder);
                    Orders = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
                    SelectedOrder = null;
                    break;
                case "Customer":
                    StationManager.CurrentCustomer = SelectedCustomer;
                    StationManager.DataStorage.RemoveCustomer(StationManager.CurrentCustomer);
                    Customers = new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
                    SelectedCustomer = null;
                    break;
                case "Cornices":
                    StationManager.CurrentCornices = SelectedCornice;
                    StationManager.DataStorage.RemoveCornices(StationManager.CurrentCornices);
                    Cornices = new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
                    SelectedCornice= null;
                    break;
                case "Workshop":
                    StationManager.CurrentWorkshop = SelectedWorkshop;
                    StationManager.DataStorage.RemoveWorkshop(StationManager.CurrentWorkshop);
                    Workshops = new ObservableCollection<Workshop>(StationManager.DataStorage.WorkshopsList);
                    SelectedWorkshop= null;
                    break;
            }
        }

        public RelayCommand<object> AddGoodsCommand =>
            _addGoodsCommand ?? (_addGoodsCommand = new RelayCommand<object>(AddGoodsImpl, CanDeleteRow));

        private void AddGoodsImpl(object obj)
        {
            StationManager.CurrentOrder = SelectedOrder;
            AddGoodsToOrder order = new AddGoodsToOrder();
            order.ShowDialog();
            if (!order.IsActive)
            {
                StationManager.DataStorage.UpdateOrdersList();
                Orders = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
            }
        }

        public RelayCommand<object> ShowOrders => _showOrders ?? (_showOrders = new RelayCommand<object>(ShowOrdersImpl, CanShowOrder));

        private bool CanShowOrder(object obj)
        {
            return StartDate < EndDate;
        }

        private void ShowOrdersImpl(object obj)
        {
            OrdersSelectedPeriod order = new OrdersSelectedPeriod(StartDate, EndDate);
            order.ShowDialog();
        }

        public RelayCommand<object> CalcProfit => _calcProfit ?? (_calcProfit = new RelayCommand<object>(CalcProfitImpl, CanCalc));

        private bool CanCalc(object obj) => !string.IsNullOrWhiteSpace(SelectedPeriod);

        private void CalcProfitImpl(object obj)
        {
            DateTime s = DateTime.Now, e = DateTime.Now;
                if (SelectedPeriod.EndsWith("period"))
                {
                    if (StartDate < EndDate)
                    {
                        s = StartDate;
                        e = EndDate;
                    }
                    else
                    {
                        MessageBox.Show("select a correct date!");
                        return;
                    }
                }
                else if (SelectedPeriod.EndsWith("week"))
                {
                    e = DateTime.Today;
                    int m, d, y;
                    if (e.Day < 7)
                    {
                        if (e.Month == 5 || e.Month == 7 || e.Month == 10 || e.Month == 12)
                        {
                            m = e.Month - 1;
                            d = e.Day - 7 + 30;
                            y = e.Year;
                        }
                        else if (e.Month == 3)
                        {
                            m = e.Month - 1;
                            d = e.Day - 7 + 28;
                            y = e.Year;
                        }
                        else if (e.Month == 2 || e.Month == 4 || e.Month == 6 || e.Month == 8 || e.Month == 9 ||
                                 e.Month == 11)
                        {
                            m = e.Month - 1;
                            d = e.Day - 7 + 31;
                            y = e.Year;
                        }
                        else
                        {
                            m = 12;
                            d = e.Day - 7 + 30;
                            y = e.Year - 1;
                        }
                    }
                    else
                    {
                        d = e.Day - 7;
                        m = e.Month;
                        y = e.Year;
                    }

                    s = new DateTime(y, m, d);

                }
                else if (SelectedPeriod.EndsWith("month"))
                {
                    e = DateTime.Now;
                    s = new DateTime(e.Month == 1 ? e.Year - 1 : e.Year, e.Month == 1 ? 12 : e.Month - 1, e.Day);
                }
                else if (SelectedPeriod.EndsWith("6 months"))
                {
                    e = DateTime.Now;
                    s = e.Month <= 6
                        ? new DateTime(e.Year - 1, e.Month + 6, e.Day)
                        : new DateTime(e.Year, e.Month - 6, e.Day);
                }
                else if (SelectedPeriod.EndsWith("year"))
                {
                    e = DateTime.Now;
                    s = new DateTime(e.Year - 1, e.Month, e.Day);
                }

                MessageBox.Show(s.ToShortDateString() + " " + e.ToShortDateString());
                NetProfit p = new NetProfit(s, e);
                p.ShowDialog();
        }

        public RelayCommand<object> ShowCustomers => _showCustomers ?? (_showCustomers = new RelayCommand<object>(ShowCustsImpl, CanShowSort));

        private bool CanShowSort(object obj)
        {
            return !string.IsNullOrWhiteSpace(SelectedSortOrder);
        }

        private void ShowCustsImpl(object obj)
        {
            ProfitableCustomers profitableCustomers = SelectedSortOrder.EndsWith("Ascending") ? new ProfitableCustomers(true) : new ProfitableCustomers(false);
            profitableCustomers.ShowDialog();

        }

        public RelayCommand<object> SelectTable => _selectTable ?? (_selectTable = new RelayCommand<object>(SelectImpl, CanSelect));

        private bool CanSelect(object obj)
        {
            return !string.IsNullOrWhiteSpace(SelectedTable);
        }

        private void SelectImpl(object obj)
        {
            MessageBox.Show(SelectedTable);
            Print print = new Print(SelectedTable);
            print.ShowDialog();
        }

        public RelayCommand<object> AddNumCommand => _addNumCommand ??
                                                     (_addNumCommand = new RelayCommand<object>(AddNumImpl,
                                                         o => SelectedCustomer != null));

        private void AddNumImpl(object obj)
        {
            StationManager.CurrentCustomer = SelectedCustomer;
            CustTelView custTelView = new CustTelView();
            custTelView.ShowDialog();
        }

        public RelayCommand<object> CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand<object>(o=>StationManager.CloseApp()));
        public RelayCommand<object> HomeCommand => _homeCommand ?? (_homeCommand = new RelayCommand<object>(o=>NavigationManager.Instance.Navigate(ViewType.SignIn)));

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
