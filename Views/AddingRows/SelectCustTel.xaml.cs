using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для SelectCustTel.xaml
    /// </summary>
    public partial class SelectCustTel : UserControl, INavigatable
    {
        public SelectCustTel()
        {
            InitializeComponent();
            DataContext = new CustTelViewModel();
        }
    }
}
