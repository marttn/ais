using ais.Tools.Navigation;
using ais.ViewModels;
using System.Windows.Controls;

namespace ais.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInView.xaml
    /// </summary>
    public partial class SignInView : UserControl, INavigatable
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new SignInViewModel();
        }

        
    }
}
