using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractView.xaml
    /// </summary>
    public partial class UpdContractView : UserControl, INavigatable
    {
        public UpdContractView()
        {
            InitializeComponent();
            DataContext = new UpdContractVM();
        }
    }
}
