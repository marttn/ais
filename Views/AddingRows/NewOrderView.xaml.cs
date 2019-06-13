using System.Windows;
using ais.Tools.Navigation;
using ais.ViewModels.AddingRowsVM;
using System.Windows.Controls;

namespace ais.Views.AddingRows
{
    /// <summary>
    /// Логика взаимодействия для NewOrderView.xaml
    /// </summary>
    public partial class NewOrderView : Window
    {
        public NewOrderView()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }

        //private void Cust_DropDownClosed(object sender, System.EventArgs e)
        //{
        //    //cust.Text = "";
        //}

        //private void Work_DropDownClosed(object sender, System.EventArgs e)
        //{
        //    //work.Select = "";
        //    //work.SelectedValue = "";
        //}

        //private void Cornice_DropDownClosed(object sender, System.EventArgs e)
        //{
        //   // cornice.SelectedValue = "";
        //}
    }
}
