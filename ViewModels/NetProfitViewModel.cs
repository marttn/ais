using System;
using System.Collections.ObjectModel;
using ais.Models;
using ais.Tools.Managers;

namespace ais.ViewModels
{
    class NetProfitViewModel
    {
        public NetProfitViewModel(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
            OrdersList = new ObservableCollection<Order>(StationManager.DataStorage.OrderSelPeriod(Start, End));
            Income = StationManager.DataStorage.Income(start, end);
            Profit = StationManager.DataStorage.Profit(start, end);
        }

        public DateTime Start { get; }
        public DateTime End { get; }
        public ObservableCollection<Order> OrdersList { get; }
        public string Income { get; }
        public string Profit { get; }
    }
}
