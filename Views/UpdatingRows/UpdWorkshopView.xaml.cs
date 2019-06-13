
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdWorkshopView.xaml
    /// </summary>
    public partial class UpdWorkshopView 
    {
        public UpdWorkshopView()
        {
            InitializeComponent();
            DataContext = new UpdWorkshopVM();
        }
    }
}
