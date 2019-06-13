using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для CustTelView.xaml
    /// </summary>
    public partial class CustTelView : Window
    {
        public CustTelView()
        {
            InitializeComponent();
            DataContext = new CustTelViewModel();
           
        }
    }
}
