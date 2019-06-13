using System.Windows;
using ais.ViewModels.AddingRowsVM;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для SelectContractorTel.xaml
    /// </summary>
    public partial class SelectContractorTel : Window
    {
        public SelectContractorTel()
        {
            InitializeComponent();
            DataContext = new ContractorTelViewModel();
        }
    }
}
