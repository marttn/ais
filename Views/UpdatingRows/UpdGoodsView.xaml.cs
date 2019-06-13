
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdGoodsView.xaml
    /// </summary>
    public partial class UpdGoodsView 
    {
        public UpdGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdGoodsVM();
        }

       
    }
}
