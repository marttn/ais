using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewCornicesView.xaml
    /// </summary>
    public partial class NewCornicesView : Window
    {
        public NewCornicesView()
        {
            InitializeComponent();
            DataContext = new CornicesViewModel();
        }
    }
}
