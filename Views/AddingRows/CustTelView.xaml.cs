using ais.Tools.Managers;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;
using System.Windows;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для CustTelView.xaml
    /// </summary>
    public partial class CustTelView : UserControl, INavigatable
    {
        public CustTelView()
        {
            InitializeComponent();
            DataContext = new CustTelViewModel();
           
        }
    }
}
