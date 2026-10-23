
namespace Lab6_Libreria.Entidad
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int CantidadDisponible { get; set; }

        public Libro(string titulo, string autor, int cantidadDisponible)
        {
            Titulo = titulo?.Trim();
            Autor = autor?.Trim();
            CantidadDisponible = cantidadDisponible;
        }
    }
}
