using System;
using System.Windows.Input;
using examen_lenguajes_visuales_1.Models;
using examen_lenguajes_visuales_1.Data;
using examen_lenguajes_visuales_1.Helpers;

namespace examen_lenguajes_visuales_1.ViewModels
{
    public class CategoriaFormViewModel : ViewModelBase
    {
        public Categoria Categoria { get; set; }
        public string Mensaje { get; set; }
        public ICommand GuardarCommand { get; }
        public Action CloseAction { get; set; }
        private bool esNuevo;

        public CategoriaFormViewModel(Categoria categoria, bool nuevo = true)
        {
            esNuevo = nuevo;
            Categoria = new Categoria
            {
                Id = categoria?.Id ?? 0,
                Nombre = categoria?.Nombre
            };
            GuardarCommand = new RelayCommand(_ => Guardar());
        }

        private void Guardar()
        {
            Mensaje = "";

            if (string.IsNullOrWhiteSpace(Categoria.Nombre))
            {
                Mensaje = "El nombre es obligatorio.";
                OnPropertyChanged(nameof(Mensaje));
                return;
            }

            using (var context = new BibliotecaContext())
            {
                if (esNuevo)
                {
                    // No duplicar categorías
                    if (context.Categorias.Any(c => c.Nombre == Categoria.Nombre))
                    {
                        Mensaje = "Ya existe una categoría con ese nombre.";
                        OnPropertyChanged(nameof(Mensaje));
                        return;
                    }
                    context.Categorias.Add(Categoria);
                }
                else
                {
                    var catBD = context.Categorias.Find(Categoria.Id);
                    if (catBD != null)
                    {
                        // No duplicar nombres en edición
                        if (context.Categorias.Any(c => c.Nombre == Categoria.Nombre && c.Id != Categoria.Id))
                        {
                            Mensaje = "Ya existe una categoría con ese nombre.";
                            OnPropertyChanged(nameof(Mensaje));
                            return;
                        }
                        catBD.Nombre = Categoria.Nombre;
                    }
                }
                context.SaveChanges();
            }
            CloseAction?.Invoke();
        }

    }
}
