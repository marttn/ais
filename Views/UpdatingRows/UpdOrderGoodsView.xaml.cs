using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdOrderViewView.xaml
    /// </summary>
    public partial class UpdOrderGoodsView : UserControl, INavigatable
    {
        public UpdOrderGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdOrderGoodsVM();
        }
    }
}
