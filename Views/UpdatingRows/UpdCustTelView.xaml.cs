
using ais.ViewModels.UpdatingRowsVM;
using System.Windows;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdCustTel.xaml
    /// </summary>
    public partial class UpdCustTel 
    {
        public UpdCustTel()
        {
            InitializeComponent();
            DataContext = new UpdCustTelVM();
        }
    }
}
