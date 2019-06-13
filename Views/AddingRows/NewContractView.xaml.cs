using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewContractView.xaml
    /// </summary>
    public partial class NewContractView : Window
    {
        public NewContractView()
        {
            InitializeComponent();
            DataContext = new ContractViewModel();
        }
    }
}
