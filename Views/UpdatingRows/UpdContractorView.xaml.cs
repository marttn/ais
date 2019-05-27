using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractorView.xaml
    /// </summary>
    public partial class UpdContractorView : UserControl, INavigatable
    {
        public UpdContractorView()
        {
            InitializeComponent();
            DataContext = new UpdContractorVM();
        }
    }
}
