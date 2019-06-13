using System.Windows;
using System.Windows.Controls;
using ais.Tools;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для Print.xaml
    /// </summary>
    public partial class Print : Window
    {
        public Print(string param)
        {
            InitializeComponent();
            DataContext = new PrintViewModel(param);
        }

        private void PrintClick(object sender, RoutedEventArgs e)
        {
            PrintDialog p = new PrintDialog();
            if (p.ShowDialog() == true)
            {
                p.PrintVisual(Table, "Print");
            }
        }
    }
}
