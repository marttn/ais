
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractorView.xaml
    /// </summary>
    public partial class UpdContractorView 
    {
        public UpdContractorView()
        {
            InitializeComponent();
            DataContext = new UpdContractorVM();
        }
    }
}
