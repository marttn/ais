
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractView.xaml
    /// </summary>
    public partial class UpdContractView 
    {
        public UpdContractView()
        {
            InitializeComponent();
            DataContext = new UpdContractVM();
        }
    }
}
