using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewGoodsView.xaml
    /// </summary>
    public partial class NewGoodsView : Window
    {
        public NewGoodsView()
        {
            InitializeComponent();
            DataContext = new GoodsViewModel();
        }
    }
}
