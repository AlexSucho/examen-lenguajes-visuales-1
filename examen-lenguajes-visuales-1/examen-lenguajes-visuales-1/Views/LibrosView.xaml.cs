using System.Windows;
using examen_lenguajes_visuales_1.ViewModels;

namespace examen_lenguajes_visuales_1.Views
{
    public partial class LibrosView : Window
    {
        public LibrosView()
        {
            InitializeComponent();
            DataContext = new LibrosViewModel();
        }
        private void Categorias_Click(object sender, RoutedEventArgs e)
        {
            var win = new CategoriasView();
            win.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
