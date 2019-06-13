using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewContractorTelView.xaml
    /// </summary>
    public partial class NewContractorTelView : Window
    {
        public NewContractorTelView()
        {
            InitializeComponent();
            DataContext = new ContractorTelViewModel();
        }
    }
}
