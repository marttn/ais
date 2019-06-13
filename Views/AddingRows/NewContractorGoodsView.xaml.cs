using System.Windows;
using ais.ViewModels.AddingRowsVM;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewContractorGoodsView.xaml
    /// </summary>
    public partial class NewContractorGoodsView : Window 
    {
        public NewContractorGoodsView()
        {
            InitializeComponent();
            DataContext = new ContractorGoodsViewModel();
        }
    }
}
