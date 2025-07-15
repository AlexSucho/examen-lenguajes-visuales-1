using System.Windows;
using examen_lenguajes_visuales_1.ViewModels;

namespace examen_lenguajes_visuales_1.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel vm)
            {
                vm.Contraseña = PasswordBox.Password;
            }
        }
    }
}
