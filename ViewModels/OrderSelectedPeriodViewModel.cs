using System;
using System.Collections.ObjectModel;
using ais.Models;
using ais.Tools.Managers;

namespace ais.ViewModels
{
    internal class OrderSelectedPeriodViewModel
    {
        public OrderSelectedPeriodViewModel(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            OrdersList = new ObservableCollection<Order>(StationManager.DataStorage.OrderSelPeriod(Start, End));
        }
        public DateTime Start { get; }
        public DateTime End { get; }
        public ObservableCollection<Order> OrdersList { get; }
    }
}
