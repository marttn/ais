
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdOrderView.xaml
    /// </summary>
    public partial class UpdOrderView 
    {
        public UpdOrderView()
        {
            InitializeComponent();
            DataContext = new UpdOrderVM();
        }
    }
}
