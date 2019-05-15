using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewCustomerView.xaml
    /// </summary>
    public partial class NewCustomerView : UserControl, INavigatable
    {
        public NewCustomerView()
        {
            InitializeComponent();
            DataContext = new CustomerViewModel();
        }
    }
}
