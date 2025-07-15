using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using examen_lenguajes_visuales_1.Models;
using examen_lenguajes_visuales_1.Data;
using examen_lenguajes_visuales_1.Helpers;
using Microsoft.EntityFrameworkCore;


namespace examen_lenguajes_visuales_1.ViewModels
{
    public class LibrosViewModel : ViewModelBase
    {
        private ObservableCollection<Libro> libros;
        public ObservableCollection<Libro> Libros
        {
            get => libros;
            set { libros = value; OnPropertyChanged(nameof(Libros)); }
        }

        private string filtro;
        public string Filtro
        {
            get => filtro;
            set
            {
                filtro = value;
                OnPropertyChanged(nameof(Filtro));
                FiltrarLibros();
            }
        }

        private Libro libroSeleccionado;
        public Libro LibroSeleccionado
        {
            get => libroSeleccionado;
            set { libroSeleccionado = value; OnPropertyChanged(nameof(LibroSeleccionado)); }
        }

        public ICommand NuevoLibroCommand { get; }
        public ICommand EditarLibroCommand { get; }
        public ICommand EliminarLibroCommand { get; }

        public LibrosViewModel()
        {
            CargarLibros();
            NuevoLibroCommand = new RelayCommand(_ => NuevoLibro());
            EditarLibroCommand = new RelayCommand(_ => EditarLibro(), _ => LibroSeleccionado != null);
            EliminarLibroCommand = new RelayCommand(_ => EliminarLibro(), _ => LibroSeleccionado != null);
        }

        private void CargarLibros()
        {
            using (var context = new BibliotecaContext())
            {
                Libros = new ObservableCollection<Libro>(
                    context.Libros
                        .Include(l => l.Categoria) // Esto es CLAVE
                        .ToList()
                );
            }
        
        }

        private void FiltrarLibros()
        {
            using (var context = new BibliotecaContext())
            {
                var query = context.Libros.Include(l => l.Categoria).AsQueryable();

                if (!string.IsNullOrWhiteSpace(Filtro))
                {
                    query = query.Where(l => l.Titulo.Contains(Filtro) || l.Autor.Contains(Filtro));
                }

                Libros = new ObservableCollection<Libro>(query.ToList());
            }
        }


        private void NuevoLibro()
        {
            var vm = new LibroFormViewModel(null, true);
            var window = new Views.LibroFormView(vm);
            window.ShowDialog();
            CargarLibros();
        }

        private void EditarLibro()
        {
            if (LibroSeleccionado != null)
            {
                var vm = new LibroFormViewModel(LibroSeleccionado, false);
                var window = new Views.LibroFormView(vm);
                window.ShowDialog();
                CargarLibros();
            }
        }

       

        private void EliminarLibro()
        {
            if (LibroSeleccionado != null)
            {
                using (var context = new BibliotecaContext())
                {
                    var libro = context.Libros.Find(LibroSeleccionado.Id);
                    if (libro != null)
                    {
                        context.Libros.Remove(libro);
                        context.SaveChanges();
                    }
                }
                CargarLibros();
            }
        }
    }
}
