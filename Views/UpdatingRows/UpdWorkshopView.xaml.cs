using ais.Tools.Navigation;
using ais.ViewModels.UpdatingRowsVM;
using System.Windows.Controls;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdWorkshopView.xaml
    /// </summary>
    public partial class UpdWorkshopView : UserControl, INavigatable
    {
        public UpdWorkshopView()
        {
            InitializeComponent();
            DataContext = new UpdWorkshopVM();
        }
    }
}
