using System.Windows;
using ais.ViewModels.UpdatingRowsVM;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractGoodsView.xaml
    /// </summary>
    public partial class UpdContractGoodsView 
    {
        public UpdContractGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdContractGoodsVM();
        }
    }
}
