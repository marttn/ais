using System.Windows;
using ais.Tools.Navigation;
using System.Windows.Controls;
using System.Windows.Media;
using ais.Tools.Managers;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для DesignerView.xaml
    /// </summary>
    public partial class DesignerView : INavigatable
    {
        public DesignerView()
        {
            InitializeComponent();
            DataContext = new DesignerViewModel();
            LoadGrid();
        }

        private void LoadGrid()
        {
            var margin = 0;
            for (var i = 0; i < StationManager.DataStorage.ListCurtains().Count; i++)
            {
                var newBtn = new Button
                {
                    Content = StationManager.DataStorage.ListCurtains()[i],
                    Margin = new Thickness(0, margin, 0, 0),
                    Background = null,
                    BorderBrush = null,
                    Height = 30,
                    FontFamily = new FontFamily("Verdana"),
                    FontSize = 12,
                    VerticalAlignment = VerticalAlignment.Top
                    };
                newBtn.Click +=NewBtnOnClick;
                margin += 30;
                CurtainsGrid.Children.Add(newBtn);
            }

            margin = 0;
            for (var j = 0; j < StationManager.DataStorage.ListCornices().Count; j++)
            {
                var newBtn = new Button
                {
                    Content = StationManager.DataStorage.ListCornices()[j],
                    Margin = new Thickness(0, margin, 0, 0),
                    Background = null,
                    BorderBrush = null,
                    Height = 30,
                    FontFamily = new FontFamily("Verdana"),
                    FontSize = 12,
                    VerticalAlignment = VerticalAlignment.Top
                };
                
                
                newBtn.Click += NewBtnOnClick;
                margin += 30;
                CornicesGrid.Children.Add(newBtn);
            }

            margin = 0;
            for (var k = 0; k < StationManager.DataStorage.ListAccs().Count; k++)
            {
                var newBtn = new Button
                {
                    Content = StationManager.DataStorage.ListAccs()[k],
                    Margin = new Thickness(0, margin, 0, 0),
                    Background = null,
                    BorderBrush = null,
                    Height = 30,
                    FontFamily = new FontFamily("Verdana"),
                    FontSize = 12,
                    VerticalAlignment = VerticalAlignment.Top
                };
                newBtn.Click += NewBtnOnClick;
                margin += 30;
                AccessoriesGrid.Children.Add(newBtn);
            }
        }


        private void NewBtnOnClick(object sender, RoutedEventArgs e)
        {
            //ContractorsPrices.Children.Clear();
            if (CurtainsGrid.Visibility == Visibility.Visible)
                CurtainsGrid.Visibility = Visibility.Hidden;
            if (CornicesGrid.Visibility == Visibility.Visible)
                CornicesGrid.Visibility = Visibility.Hidden;
            if (AccessoriesGrid.Visibility == Visibility.Visible)
                AccessoriesGrid.Visibility = Visibility.Hidden;
            var btn = (Button) sender;
            DataGrid.ItemsSource = StationManager.DataStorage.CurrentContractorsPrices(btn.Content.ToString());
            ContractorsPrices.Visibility = Visibility.Visible;
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


        private void CurtainsClick(object sender, RoutedEventArgs e)
        {
            CurtainsGrid.Visibility = Visibility.Visible;
            ContractorsPrices.Visibility = Visibility.Hidden;
        }

        private void CornicesClick(object sender, RoutedEventArgs e)
        {
            CornicesGrid.Visibility = Visibility.Visible;
            ContractorsPrices.Visibility = Visibility.Hidden;
        }

        private void AccsClick(object sender, RoutedEventArgs e)
        {
            AccessoriesGrid.Visibility = Visibility.Visible;
            ContractorsPrices.Visibility = Visibility.Hidden;
        }
    }
}
