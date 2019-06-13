
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdCornicesView.xaml
    /// </summary>
    public partial class UpdCornicesView 
    {
        public UpdCornicesView()
        {
            InitializeComponent();
            DataContext = new UpdCornicesVM();
        }
    }
}
