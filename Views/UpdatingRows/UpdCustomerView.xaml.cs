using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdCustomerView.xaml
    /// </summary>
    public partial class UpdCustomerView : UserControl, INavigatable
    {
        public UpdCustomerView()
        {
            InitializeComponent();
            DataContext = new UpdCustomerVM();
        }
    }
}
