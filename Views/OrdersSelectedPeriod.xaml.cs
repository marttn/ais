using System;
using System.Windows;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для OrdersSelectedPeriod.xaml
    /// </summary>
    public partial class OrdersSelectedPeriod : Window
    {
        public OrdersSelectedPeriod(DateTime start, DateTime end)
        {
            InitializeComponent();
            DataContext = new OrderSelectedPeriodViewModel(start, end);
        }
    }
}
