using System.Windows;
using examen_lenguajes_visuales_1.ViewModels;

namespace examen_lenguajes_visuales_1.Views
{
    public partial class CategoriaFormView : Window
    {
        public CategoriaFormView(CategoriaFormViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
            vm.CloseAction = this.Close;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
