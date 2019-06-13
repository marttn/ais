using System.Windows;
using ais.ViewModels.AddingRowsVM;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewCustomerView.xaml
    /// </summary>
    public partial class NewCustomerView : Window
    {
        public NewCustomerView()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
        }
    }
}
