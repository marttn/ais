using System.Windows;
using ais.Tools.Navigation;
using System.Windows.Controls;
using ais.Models;
using ais.Tools.Managers;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для DesignerView.xaml
    /// </summary>
    public partial class DesignerView : UserControl, INavigatable
    {
        public DesignerView()
        {
            InitializeComponent();
            DataContext = new DesignerViewModel();
            var first = new DataGridTextColumn
            {
                Header = "Name"
            };
             Goods.Columns.Add(first);
            for (int i = 0; i < StationManager.DataStorage.NameContractors().Count; i++)
            {
                var t = new DataGridTextColumn
                {
                    Header = StationManager.DataStorage.NameContractors()[i]
                };
                Goods.Columns.Add(t);
            }
            
            Goods.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        private void OrderClick(object sender, RoutedEventArgs e)
        {
            Customers.Visibility = Visibility.Hidden;
            Cornices.Visibility = Visibility.Hidden;
            Workshops.Visibility = Visibility.Hidden;
            Prices.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Visible;
            StationManager.CurrentTableType = "Order";
        }

        private void CustomerClick(object sender, RoutedEventArgs e)
        {
            Cornices.Visibility = Visibility.Hidden;
            Workshops.Visibility = Visibility.Hidden;
            Prices.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Hidden;
            Customers.Visibility = Visibility.Visible;
            StationManager.CurrentTableType = "Customer";
        }

        private void CorniceClick(object sender, RoutedEventArgs e)
        {
            Workshops.Visibility = Visibility.Hidden;
            Prices.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Hidden;
            Customers.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Hidden;
            Cornices.Visibility = Visibility.Visible;
            StationManager.CurrentTableType = "Cornices";
        }

        private void WorkshopClick(object sender, RoutedEventArgs e)
        {
            Prices.Visibility = Visibility.Hidden;
            Orders.Visibility = Visibility.Hidden;
            Customers.Visibility = Visibility.Hidden;
            Cornices.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Hidden;
            Workshops.Visibility = Visibility.Visible;
            StationManager.CurrentTableType = "Workshop";
        }

        private void PricesClick(object sender, RoutedEventArgs e)
        {
            Orders.Visibility = Visibility.Hidden;
            Customers.Visibility = Visibility.Hidden;
            Cornices.Visibility = Visibility.Hidden;
            Workshops.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Hidden;
            Prices.Visibility = Visibility.Visible;
            StationManager.CurrentTableType = "Goods";
        }

        private void ReportsClick(object sender, RoutedEventArgs e)
        {
            Orders.Visibility = Visibility.Hidden;
            Customers.Visibility = Visibility.Hidden;
            Cornices.Visibility = Visibility.Hidden;
            Workshops.Visibility = Visibility.Hidden;
            Prices.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Visible;
        }

        
    }
}
