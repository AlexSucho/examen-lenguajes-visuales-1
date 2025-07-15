using System.Windows;
using examen_lenguajes_visuales_1.ViewModels;

namespace examen_lenguajes_visuales_1.Views
{
    public partial class CategoriasView : Window
    {
        public CategoriasView()
        {
            InitializeComponent();
            DataContext = new CategoriasViewModel();
        }
    }
}
