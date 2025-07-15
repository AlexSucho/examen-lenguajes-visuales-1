using Microsoft.EntityFrameworkCore;
using examen_lenguajes_visuales_1.Models;

namespace examen_lenguajes_visuales_1.Data
{
    public class BibliotecaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Libro> Libros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Cambia el Data Source y nombre de tu base de datos
            optionsBuilder.UseSqlServer(@"Server=ASU-EA-L001-PC-;Database=BibliotecaDB;Trusted_Connection=True;TrustServerCertificate=True;");

        }
    }
}
