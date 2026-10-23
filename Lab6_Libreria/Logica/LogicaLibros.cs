
using System;
using System.Data;
using Lab6_Libreria.Datos;
using Lab6_Libreria.Entidad;

namespace Lab6_Libreria.Logica
{
    public class LogicaLibros
    {
        // Objeto para acceder a la base de datos
        private readonly DatosLibros libroDatos;

        public LogicaLibros()
        {
            libroDatos = new DatosLibros();
        }

        // Consulta los libros registrados
        public DataTable ConsultarLibros(bool soloDisponibles = false)
        {
            return libroDatos.ConsultarLibros(soloDisponibles);
        }

        // Valida y registra un libro
        public int AgregarLibro(Libro libro)
        {
            if (libro == null)
            {
                throw new ArgumentNullException(
                    nameof(libro), "El libro no puede ser nulo.");
            }

            ValidarDatos(libro.Titulo, libro.Autor,
                libro.CantidadDisponible);

            return libroDatos.AgregarLibro(
                libro.Titulo.Trim(),
                libro.Autor.Trim(),
                libro.CantidadDisponible);
        }

        // Actualiza la cantidad de ejemplares
        public void ActualizarCantidad(int id, int cantidad)
        {
            ValidarId(id);

            if (cantidad < 0)
            {
                throw new ArgumentException(
                    "La cantidad disponible no puede ser negativa.");
            }

            libroDatos.ActualizarCantidad(id, cantidad);
        }

        // Elimina un libro del inventario
        public void EliminarLibro(int id)
        {
            ValidarId(id);

            libroDatos.EliminarLibro(id);
        }

        // Validaciones para registrar libros
        private void ValidarDatos(
            string titulo, string autor, int cantidad)
        {
            if (string.IsNullOrWhiteSpace(titulo))
            {
                throw new ArgumentException(
                    "El título del libro es obligatorio.");
            }

            if (titulo.Trim().Length > 200)
            {
                throw new ArgumentException(
                    "El título no puede superar los 200 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(autor))
            {
                throw new ArgumentException(
                    "El autor del libro es obligatorio.");
            }

            if (autor.Trim().Length > 150)
            {
                throw new ArgumentException(
                    "El autor no puede superar los 150 caracteres.");
            }

            if (cantidad < 0)
            {
                throw new ArgumentException(
                    "La cantidad disponible no puede ser negativa.");
            }
        }

        // Verifica que el identificador sea válido
        private void ValidarId(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(
                    "Debe seleccionar un libro válido.");
            }
        }
    }
}
