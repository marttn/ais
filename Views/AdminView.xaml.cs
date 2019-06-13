using ais.Tools.Navigation;
using ais.ViewModels;
using System.Windows.Controls;
using System.Windows;
using Button = System.Windows.Controls.Button;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : INavigatable
    {
        public AdminView()
        {
            InitializeComponent();
            DataContext = new AdminViewModel();
        }

        private void ShowTableClick(object sender, RoutedEventArgs e)
        {
            Reports.Visibility = Visibility.Hidden;
            UserList.Visibility = Visibility.Hidden;
            Tables.Visibility = Visibility.Visible;
            CurrentTable.Children.Clear();
            buttons.Visibility = Visibility.Hidden;
        }

        private void ShowSelectedTable(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            btn?.Command.Execute(btn.CommandParameter);
            Tables.Visibility = Visibility.Hidden;
            CurrentTable.Children.Add(SelectedTableDataGrid);
            CurrentTable.Visibility = Visibility.Visible;
            SelectedTableDataGrid.HeadersVisibility = DataGridHeadersVisibility.Column;
            buttons.Visibility = Visibility.Visible;
        }


        private void ShowUsersClick(object sender, RoutedEventArgs e)
        {
            Reports.Visibility = Visibility.Hidden;
            Tables.Visibility = Visibility.Hidden;
            CurrentTable.Visibility = Visibility.Hidden;
            buttons.Visibility = Visibility.Hidden;
            UserList.Visibility = Visibility.Visible;
        }

        private void ShowReportsClick(object sender, RoutedEventArgs e)
        {
            Tables.Visibility = Visibility.Hidden;
            CurrentTable.Visibility = Visibility.Hidden;
            buttons.Visibility = Visibility.Hidden;
            UserList.Visibility = Visibility.Hidden;
            Reports.Visibility = Visibility.Visible;
        }

        
    }
}
