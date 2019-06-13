
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractorGoodsView.xaml
    /// </summary>
    public partial class UpdContractorGoodsView 
    {
        public UpdContractorGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdContractorGoodsVM();
        }

       
    }
}
