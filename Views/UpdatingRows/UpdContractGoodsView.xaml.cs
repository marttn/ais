using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractGoodsView.xaml
    /// </summary>
    public partial class UpdContractGoodsView : UserControl, INavigatable
    {
        public UpdContractGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdContractGoodsVM();
        }
    }
}
