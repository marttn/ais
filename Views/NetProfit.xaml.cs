using System;
using System.Windows;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для NetProfit.xaml
    /// </summary>
    public partial class NetProfit : Window
    {
        public NetProfit(DateTime start, DateTime end)
        {
            InitializeComponent();
            DataContext = new NetProfitViewModel(start, end);
        }
    }
}
