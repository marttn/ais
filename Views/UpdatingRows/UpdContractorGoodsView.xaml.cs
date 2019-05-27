using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractorGoodsView.xaml
    /// </summary>
    public partial class UpdContractorGoodsView : UserControl, INavigatable
    {
        public UpdContractorGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdContractorGoodsVM();
        }

       
    }
}
