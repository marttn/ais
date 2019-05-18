using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewContractorGoodsView.xaml
    /// </summary>
    public partial class NewContractorGoodsView : UserControl, INavigatable
    {
        public NewContractorGoodsView()
        {
            InitializeComponent();
            DataContext = new ContractorGoodsViewModel();
        }
    }
}
