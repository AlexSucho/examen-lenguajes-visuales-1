using System.Windows;
using examen_lenguajes_visuales_1.ViewModels;

namespace examen_lenguajes_visuales_1.Views
{
    public partial class RegistroView : Window
    {
        public RegistroView()
        {
            InitializeComponent();
            DataContext = new RegistroViewModel(this);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is RegistroViewModel vm)
            {
                vm.Contraseña = PasswordBox.Password;
            }
        }
    }
}

