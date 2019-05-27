using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdOrderView.xaml
    /// </summary>
    public partial class UpdOrderView : UserControl, INavigatable
    {
        public UpdOrderView()
        {
            InitializeComponent();
            DataContext = new UpdOrderVM();
        }
    }
}
