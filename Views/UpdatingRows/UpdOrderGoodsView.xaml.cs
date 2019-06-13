using System.Windows;
using ais.ViewModels.UpdatingRowsVM;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdOrderViewView.xaml
    /// </summary>
    public partial class UpdOrderGoodsView : Window
    {
        public UpdOrderGoodsView()
        {
            InitializeComponent();
            DataContext = new UpdOrderGoodsVM();
        }
    }
}
