using ais.ViewModels.AddingRowsVM;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для SelectCustTel.xaml
    /// </summary>
    public partial class SelectCustTel
    {
        public SelectCustTel()
        {
            InitializeComponent();
            DataContext = new CustTelViewModel();
        }
    }
}
