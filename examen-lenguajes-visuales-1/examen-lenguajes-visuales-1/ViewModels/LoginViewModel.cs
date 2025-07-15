using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using examen_lenguajes_visuales_1.Models;
using examen_lenguajes_visuales_1.Data;
using examen_lenguajes_visuales_1.Helpers;
using System.Windows;

namespace examen_lenguajes_visuales_1.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string usuario;
        private string contraseña;
        private string mensaje;

        public string Usuario
        {
            get => usuario;
            set { usuario = value; OnPropertyChanged(nameof(Usuario)); }
        }

        public string Contraseña
        {
            get => contraseña;
            set { contraseña = value; OnPropertyChanged(nameof(Contraseña)); }
        }

        public string Mensaje
        {
            get => mensaje;
            set { mensaje = value; OnPropertyChanged(nameof(Mensaje)); }
        }

        public ICommand LoginCommand { get; }
        public ICommand AbrirRegistroCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            AbrirRegistroCommand = new RelayCommand(AbrirRegistro);
        }

        private void Login(object parameter)
        {
            using (var context = new BibliotecaContext())
            {
                var usuarioDb = context.Usuarios
                    .FirstOrDefault(u => u.UsuarioLogin == Usuario && u.Contraseña == Contraseña);

                if (usuarioDb != null)
                {
                    Mensaje = "¡Login correcto!";
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        var librosView = new examen_lenguajes_visuales_1.Views.LibrosView();
                        librosView.Show();
                        foreach (Window window in Application.Current.Windows)
                        {
                            if (window is examen_lenguajes_visuales_1.Views.LoginView)
                            {
                                window.Close();
                                break;
                            }
                        }
                    });
                }
                else
                {
                    Mensaje = "Usuario o contraseña incorrectos";
                }
            }
        }

        private void AbrirRegistro(object parameter)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var registro = new examen_lenguajes_visuales_1.Views.RegistroView();
                registro.ShowDialog(); // Modal, espera a que cierre
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
