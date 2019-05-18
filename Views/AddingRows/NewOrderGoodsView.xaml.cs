using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderGoodsView.xaml
    /// </summary>
    public partial class NewOrderGoodsView : UserControl, INavigatable
    {
        public NewOrderGoodsView()
        {
            InitializeComponent();
            DataContext = new OrderGoodsViewModel();
        }
    }
}
