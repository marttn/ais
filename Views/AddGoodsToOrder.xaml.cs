using System.Windows;
using ais.ViewModels.AddingRowsVM;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для AddGoodsToOrder.xaml
    /// </summary>
    public partial class AddGoodsToOrder
    {
        public AddGoodsToOrder()
        {
            InitializeComponent();
            DataContext = new OrderGoodsViewModel();
        }
    }
}
