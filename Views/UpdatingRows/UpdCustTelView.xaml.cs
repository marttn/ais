using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdCustTel.xaml
    /// </summary>
    public partial class UpdCustTel : UserControl, INavigatable
    {
        public UpdCustTel()
        {
            InitializeComponent();
            DataContext = new UpdCustTelVM();
        }
    }
}
