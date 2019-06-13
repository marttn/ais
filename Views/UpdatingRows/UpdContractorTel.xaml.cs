using ais.ViewModels.UpdatingRowsVM;

namespace ais.Views.UpdatingRows
{
    /// <summary>
    /// Логика взаимодействия для UpdContractorTel.xaml
    /// </summary>
    public partial class UpdContractorTel 
    {
        public UpdContractorTel()
        {
            InitializeComponent();
            DataContext = new UpdContractorTelVM();
        }
    }
}
