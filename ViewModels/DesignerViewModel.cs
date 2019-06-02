using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ais.Models;
using ais.Tools;
using ais.Tools.Managers;
using ais.Tools.Navigation;

namespace ais.ViewModels
{
    internal class DesignerViewModel
    {
        private string _name;
        private string _lastName;
        private string _login;
        private string _type;
        private Order _selectedOrder;
        private Customer _selectedCustomer;
        private Cornices _selectedCornices;
        private Workshop _selectedWorkshop;


        private RelayCommand<object> _addCommand;
        private RelayCommand<object> _updateCommand;
        private RelayCommand<object> _deleteCommand;

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

        //public string SelectedContractor
        //{
        //    get => _selectedContractor;
        //    set
        //    {
        //        _selectedContractor = value;
        //        OnPropertyChanged("SelectedContractor");
        //        OnPropertyChanged("ListSelectedGoods");
        //        //MessageBox.Show(StationManager.SelectedContractor);
        //    }
        //}

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged("SelectedCustomer");
            }
        }

        public Cornices SelectedCornice
        {
            get => _selectedCornices;
            set
            {
                _selectedCornices = value;
                OnPropertyChanged("SelectedCornice");
            }
        }

        public Workshop SelectedWorkshop
        {
            get => _selectedWorkshop;
            set
            {
                _selectedWorkshop = value;
                OnPropertyChanged("SelectedWorkshop");
            }
        }

        public ObservableCollection<Order> Orders { get; set; } = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
        public ObservableCollection<Customer> Customers { get; set; } = new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
        public ObservableCollection<Cornices> Cornices { get; set; } = new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
        public ObservableCollection<Workshop> Workshops { get; set; } = new ObservableCollection<Workshop>(StationManager.DataStorage.WorkshopsList);
        //public ObservableCollection<string> ListContractors { get; set; } = new ObservableCollection<string>(StationManager.DataStorage.NameContractors());
        // public ObservableCollection<string> ListNameGoods { get; set; } = new ObservableCollection<string>(StationManager.DataStorage.NameGoods());


        public RelayCommand<object> AddCommand => _addCommand ?? (_addCommand = new RelayCommand<object>(AddRowImplementation));

        private void AddRowImplementation(object obj)
        {
            switch (StationManager.CurrentTableType)
            {
                case "Order":
                    NavigationManager.Instance.Navigate(ViewType.NewOrder);
                    Orders = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
                    break;
                case "Customer":
                    NavigationManager.Instance.Navigate(ViewType.NewCustomer);
                    Customers = new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
                    break;
                case "Cornices":
                    NavigationManager.Instance.Navigate(ViewType.NewCornices);
                    Cornices = new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
                    break;
                case "Workshop":
                    NavigationManager.Instance.Navigate(ViewType.NewWorkshop);
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
                    NavigationManager.Instance.Navigate(ViewType.UpdOrder);
                    Orders = new ObservableCollection<Order>(StationManager.DataStorage.OrdersList);
                    SelectedOrder = null;
                    break;
                case "Customer":
                    StationManager.CurrentCustomer = SelectedCustomer;
                    NavigationManager.Instance.Navigate(ViewType.UpdCustomer);
                    Customers = new ObservableCollection<Customer>(StationManager.DataStorage.CustomersList);
                    SelectedCustomer = null;
                    break;
                case "Cornices":
                    StationManager.CurrentCornices = SelectedCornice;
                    NavigationManager.Instance.Navigate(ViewType.UpdCornices);
                    Cornices = new ObservableCollection<Cornices>(StationManager.DataStorage.CornicesList);
                    SelectedCornice = null;
                    break;
                case "Workshop":
                    StationManager.CurrentWorkshop = SelectedWorkshop;
                    NavigationManager.Instance.Navigate(ViewType.UpdWorkshop);
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

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
