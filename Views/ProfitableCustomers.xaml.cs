using System.Windows;
using ais.ViewModels;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для ProfitableCustomers.xaml
    /// </summary>
    public partial class ProfitableCustomers : Window
    {
        public ProfitableCustomers(bool asc)
        {
            InitializeComponent();
            DataContext = new ProfitableCustomersViewModel(asc);
        }
    }
}
