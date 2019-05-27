using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdGoodsView.xaml
    /// </summary>
    public partial class UpdGoodsView : UserControl, INavigatable
    {
        public UpdGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdGoodsVM();
        }

       
    }
}
