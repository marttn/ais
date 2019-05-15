using ais.Tools.Navigation;
using ais.ViewModels;
using System.Windows.Controls;

namespace ais.Views
{ 
    /// <summary>
    /// Логика взаимодействия для SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl, INavigatable
    {
        public SignUpView()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }    
    }
}
