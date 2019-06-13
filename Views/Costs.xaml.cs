using System;
using System.Windows;
using System.Windows.Controls;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для Costs.xaml
    /// </summary>
    public partial class Costs : Window
    {
        public Costs(DateTime start, DateTime end)
        {
            InitializeComponent();
            DataContext = new CostsViewModel(start, end);
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
            {
                p.PrintVisual(GridCosts, "Print");
            }
        }
    }
}
