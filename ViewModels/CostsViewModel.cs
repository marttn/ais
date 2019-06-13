using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ais.Models;
using ais.Tools.Managers;

namespace ais.ViewModels
{
    class CostsViewModel
    {
        public CostsViewModel(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            OrdersList = new ObservableCollection<Order>(StationManager.DataStorage.OrderSelPeriod(Start, End));
            ContractsList = new ObservableCollection<Contract>(StationManager.DataStorage.ContractSelPeriod(Start, End));
            Income = StationManager.DataStorage.Income(start, end);
            Expenses = StationManager.DataStorage.Expenses(start, end);
            Profit = StationManager.DataStorage.RevenueAdmin(start, end);
        }

        private string _income;
        private string _expenses;
        private string _profit;

        public string Income
        {
            get => $"Income: {_income}";
            set
            {
                _income = value;
                OnPropertyChanged();
            }
        }
        public string Expenses
        {
            get => $"Expenses: {_expenses}";
            set
            {
                _expenses = value;
                OnPropertyChanged();
            }
        }
        public string Profit
        {
            get => $"Revenue: {_profit}";
            set
            {
                _profit = value;
                OnPropertyChanged();
            }
        }
        public DateTime Start { get; }
        public DateTime End { get; }
        public ObservableCollection<Order> OrdersList { get; }
        public ObservableCollection<Contract> ContractsList { get; }


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
