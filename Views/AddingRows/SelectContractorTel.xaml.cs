using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для SelectContractorTel.xaml
    /// </summary>
    public partial class SelectContractorTel : UserControl, INavigatable
    {
        public SelectContractorTel()
        {
            InitializeComponent();
            DataContext = new ContractorTelViewModel();
        }
    }
}
