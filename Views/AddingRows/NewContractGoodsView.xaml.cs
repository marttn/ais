using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewContractGoodsView.xaml
    /// </summary>
    public partial class NewContractGoodsView : UserControl, INavigatable
    {
        public NewContractGoodsView()
        {
            InitializeComponent();
            DataContext = new ContractGoodsViewModel();
        }
    }
}
