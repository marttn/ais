using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewContractorView.xaml
    /// </summary>
    public partial class NewContractorView : UserControl, INavigatable
    {
        public NewContractorView()
        {
            InitializeComponent();
            DataContext = new ContractorViewModel();
        }
    }
}
