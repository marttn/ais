using ais.Tools.Navigation;
using ais.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl, INavigatable
    {
        public AdminView()
        {
            InitializeComponent();
            DataContext = new AdminViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tables.Visibility = Visibility.Visible;
            something.Children.Clear();
            buttons.Visibility = Visibility.Hidden;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn.Command.Execute(btn.CommandParameter);
            Tables.Visibility = Visibility.Hidden;
            something.Children.Add(DataGrid);
            DataGrid.Visibility = Visibility.Visible;
            DataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
            //if (btn.CommandParameter.Equals("Contractor_Tel") || btn.CommandParameter.Equals("Cust_Tel"))
            //    buttons_tel.Visibility = Visibility.Visible;
            //else
            buttons.Visibility = Visibility.Visible;
        }

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    something.Children.Clear();
        //    var btn = sender as Button;
        //    btn.Command.Execute(btn.CommandParameter);
        //    something.Children.Add(DataGrid);
        //    DataGrid.Visibility = Visibility.Visible;
        //    DataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
        //}
    }
}
