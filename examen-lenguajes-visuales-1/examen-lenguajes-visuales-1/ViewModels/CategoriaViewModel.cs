using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using examen_lenguajes_visuales_1.Models;
using examen_lenguajes_visuales_1.Data;
using examen_lenguajes_visuales_1.Helpers;

namespace examen_lenguajes_visuales_1.ViewModels
{
    public class CategoriasViewModel : ViewModelBase
    {
        public ObservableCollection<Categoria> Categorias { get; set; }
        private Categoria categoriaSeleccionada;
        public Categoria CategoriaSeleccionada
        {
            get => categoriaSeleccionada;
            set { categoriaSeleccionada = value; OnPropertyChanged(nameof(CategoriaSeleccionada)); }
        }

        public ICommand NuevaCategoriaCommand { get; }
        public ICommand EditarCategoriaCommand { get; }
        public ICommand EliminarCategoriaCommand { get; }

        public CategoriasViewModel()
        {
            CargarCategorias();
            NuevaCategoriaCommand = new RelayCommand(_ => NuevaCategoria());
            EditarCategoriaCommand = new RelayCommand(_ => EditarCategoria(), _ => CategoriaSeleccionada != null);
            EliminarCategoriaCommand = new RelayCommand(_ => EliminarCategoria(), _ => CategoriaSeleccionada != null);
        }

        private void CargarCategorias()
        {
            using (var context = new BibliotecaContext())
            {
                Categorias = new ObservableCollection<Categoria>(context.Categorias.ToList());
                OnPropertyChanged(nameof(Categorias));
            }
        }

        private void NuevaCategoria()
        {
            var vm = new CategoriaFormViewModel(null, true);
            var win = new Views.CategoriaFormView(vm);
            win.ShowDialog();
            CargarCategorias();
        }

        private void EditarCategoria()
        {
            if (CategoriaSeleccionada != null)
            {
                var vm = new CategoriaFormViewModel(CategoriaSeleccionada, false);
                var win = new Views.CategoriaFormView(vm);
                win.ShowDialog();
                CargarCategorias();
            }
        }

        private void EliminarCategoria()
        {
            if (CategoriaSeleccionada != null)
            {
                using (var context = new BibliotecaContext())
                {
                    var cat = context.Categorias.Find(CategoriaSeleccionada.Id);
                    if (cat != null)
                    {
                        context.Categorias.Remove(cat);
                        context.SaveChanges();
                    }
                }
                CargarCategorias();
            }
        }
    }
}
