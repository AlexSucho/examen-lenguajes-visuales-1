using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using examen_lenguajes_visuales_1.Models;
using examen_lenguajes_visuales_1.Data;
using examen_lenguajes_visuales_1.Helpers;

namespace examen_lenguajes_visuales_1.ViewModels
{
    public class LibroFormViewModel : ViewModelBase
    {
        public Libro Libro { get; set; }
        public ObservableCollection<Categoria> Categorias { get; set; }
        public string Mensaje { get; set; }
        public ICommand GuardarCommand { get; }
        public Action CloseAction { get; set; }

        private bool esNuevo;

        public LibroFormViewModel(Libro libro, bool nuevo = true)
        {
            using (var context = new BibliotecaContext())
            {
                Categorias = new ObservableCollection<Categoria>(context.Categorias.ToList());
            }

            esNuevo = nuevo;

            // Copia los datos para edición o nuevo registro
            Libro = new Libro
            {
                Id = libro?.Id ?? 0,
                Titulo = libro?.Titulo,
                Autor = libro?.Autor,
                CategoriaId = libro?.CategoriaId ?? (Categorias.Count > 0 ? Categorias[0].Id : 0)
            };

            GuardarCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            Mensaje = "";

            if (string.IsNullOrWhiteSpace(Libro.Titulo))
            {
                Mensaje = "El título es obligatorio.";
                OnPropertyChanged(nameof(Mensaje));
                return;
            }
            if (string.IsNullOrWhiteSpace(Libro.Autor))
            {
                Mensaje = "El autor es obligatorio.";
                OnPropertyChanged(nameof(Mensaje));
                return;
            }
            if (Libro.CategoriaId == 0)
            {
                Mensaje = "Selecciona una categoría.";
                OnPropertyChanged(nameof(Mensaje));
                return;
            }

            using (var context = new BibliotecaContext())
            {
                if (esNuevo)
                {
                    context.Libros.Add(Libro);
                }
                else
                {
                    var libroBD = context.Libros.Find(Libro.Id);
                    if (libroBD != null)
                    {
                        libroBD.Titulo = Libro.Titulo;
                        libroBD.Autor = Libro.Autor;
                        libroBD.CategoriaId = Libro.CategoriaId;
                    }
                }
                context.SaveChanges();
            }
            CloseAction?.Invoke();
        }

    }
}
