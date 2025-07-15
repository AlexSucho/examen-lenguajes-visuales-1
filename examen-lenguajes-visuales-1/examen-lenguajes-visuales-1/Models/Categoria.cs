namespace examen_lenguajes_visuales_1.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        // Relación: una categoría puede tener muchos libros
        public ICollection<Libro> Libros { get; set; }
    }
}
