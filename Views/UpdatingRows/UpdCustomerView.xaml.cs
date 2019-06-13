
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdCustomerView.xaml
    /// </summary>
    public partial class UpdCustomerView 
    {
        public UpdCustomerView()
        {
            InitializeComponent();
            DataContext = new UpdCustomerVM();
        }
    }
}
