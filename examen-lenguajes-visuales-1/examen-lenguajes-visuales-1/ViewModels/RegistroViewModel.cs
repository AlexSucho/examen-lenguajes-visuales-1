using System.ComponentModel;
using System.Windows.Input;
using System.Linq;
using examen_lenguajes_visuales_1.Models;
using examen_lenguajes_visuales_1.Data;
using examen_lenguajes_visuales_1.Helpers;
using System.Windows;

namespace examen_lenguajes_visuales_1.ViewModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        private string usuario;
        private string contraseña;
        private string mensaje;
        private Window registroWindow;

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

        public ICommand RegistrarCommand { get; }

        public RegistroViewModel(Window window)
        {
            registroWindow = window;
            RegistrarCommand = new RelayCommand(Registrar);
        }

        private void Registrar(object parameter)
        {
            using (var context = new BibliotecaContext())
            {
                if (context.Usuarios.Any(u => u.UsuarioLogin == Usuario))
                {
                    Mensaje = "El usuario ya existe";
                }
                else
                {
                    var nuevoUsuario = new Usuario
                    {
                        Nombre = Usuario,
                        UsuarioLogin = Usuario,
                        Contraseña = Contraseña
                    };
                    context.Usuarios.Add(nuevoUsuario);
                    context.SaveChanges();
                    Mensaje = "¡Usuario registrado!";
                    // Cierra la ventana de registro y vuelve al login
                    registroWindow.Dispatcher.Invoke(() =>
                    {
                        registroWindow.Close();
                    });
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
