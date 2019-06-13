using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewWorkshopView.xaml
    /// </summary>
    public partial class NewWorkshopView 
    {
        public NewWorkshopView()
        {
            InitializeComponent();
            DataContext = new WorkshopViewModel();
        }
    }
}
