using System;
using System.Data;
using System.Windows.Forms;
using Lab6_Libreria.Entidad;
using Lab6_Libreria.Logica;
using Microsoft.Data.SqlClient;

namespace Lab6_Libreria
{
    public partial class Form1 : Form
    {
        private readonly LogicaLibros _logica;
        private int _idSeleccionado;
        private bool _cargando;

        public Form1()
        {
            InitializeComponent();
            _logica = new LogicaLibros();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void CargarLibros()
        {
            try
            {
                _cargando = true;
                dgvLibros.DataSource = _logica.ConsultarLibros(chkSoloDisponibles.Checked);
                ConfigurarColumnas();
                dgvLibros.ClearSelection();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
            finally
            {
                _cargando = false;
            }

            LimpiarCampos();
        }

        private void ConfigurarColumnas()
        {
            if (dgvLibros.Columns.Count < 4)
            {
                return;
            }

            dgvLibros.Columns["id"].HeaderText = "ID";
            dgvLibros.Columns["id"].FillWeight = 20;
            dgvLibros.Columns["Titulo"].HeaderText = "Título";
            dgvLibros.Columns["Titulo"].FillWeight = 100;
            dgvLibros.Columns["Autor"].HeaderText = "Autor";
            dgvLibros.Columns["Autor"].FillWeight = 70;
            dgvLibros.Columns["CantidadDisponible"].HeaderText = "Cantidad disponible";
            dgvLibros.Columns["CantidadDisponible"].FillWeight = 40;
        }

        private void LimpiarCampos()
        {
            _idSeleccionado = 0;
            tbTitulo.Clear();
            tbAutor.Clear();
            tbCantidad.Clear();
            tbTitulo.ReadOnly = false;
            tbAutor.ReadOnly = false;
            epValidacion.Clear();
            dgvLibros.ClearSelection();
            ActualizarEstadoBotones();
            tbTitulo.Focus();
        }

        private void ActualizarEstadoBotones()
        {
            bool modoEdicion = _idSeleccionado > 0;
            bool hayCantidad = !string.IsNullOrWhiteSpace(tbCantidad.Text);
            bool hayTextos = !string.IsNullOrWhiteSpace(tbTitulo.Text)
                && !string.IsNullOrWhiteSpace(tbAutor.Text);

            btAgregar.Enabled = !modoEdicion && hayTextos && hayCantidad;
            btActualizar.Enabled = modoEdicion && hayCantidad;
            btEliminar.Enabled = modoEdicion;
        }

        private bool ValidarCampos(bool validarTextos)
        {
            epValidacion.Clear();
            Control primerError = null;

            if (validarTextos)
            {
                if (string.IsNullOrWhiteSpace(tbTitulo.Text))
                {
                    epValidacion.SetError(tbTitulo, "Ingrese el título del libro.");
                    primerError = tbTitulo;
                }

                if (string.IsNullOrWhiteSpace(tbAutor.Text))
                {
                    epValidacion.SetError(tbAutor, "Ingrese el autor del libro.");
                    if (primerError == null)
                    {
                        primerError = tbAutor;
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(tbCantidad.Text))
            {
                epValidacion.SetError(tbCantidad, "Ingrese la cantidad disponible.");
                if (primerError == null)
                {
                    primerError = tbCantidad;
                }
            }
            else if (!int.TryParse(tbCantidad.Text.Trim(), out int cantidad) || cantidad < 0)
            {
                epValidacion.SetError(tbCantidad, "La cantidad debe ser un número entero mayor o igual a cero.");
                if (primerError == null)
                {
                    primerError = tbCantidad;
                }
            }

            if (primerError != null)
            {
                MessageBox.Show(
                    "Revise los campos marcados con el ícono de advertencia.",
                    "Datos incompletos o inválidos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                primerError.Focus();
                return false;
            }

            return true;
        }

        private void MostrarError(Exception ex)
        {
            string titulo;
            string mensaje;
            MessageBoxIcon icono = MessageBoxIcon.Error;

            if (ex is ArgumentException)
            {
                titulo = "Datos inválidos";
                mensaje = ex.Message;
                icono = MessageBoxIcon.Warning;
            }
            else if (ex is SqlException)
            {
                titulo = "Error de base de datos";
                mensaje = "No se pudo completar la operación en la base de datos.\n\n" + ex.Message;
            }
            else if (ex is InvalidOperationException)
            {
                titulo = "Error de configuración";
                mensaje = ex.Message;
            }
            else
            {
                titulo = "Error inesperado";
                mensaje = "Ocurrió un error inesperado.\n\n" + ex.Message;
            }

            MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, icono);
        }

        private void btAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(true))
            {
                return;
            }

            try
            {
                int cantidad = int.Parse(tbCantidad.Text.Trim());
                Libro libro = new Libro(tbTitulo.Text, tbAutor.Text, cantidad);
                int nuevoId = _logica.AgregarLibro(libro);

                MessageBox.Show(
                    "El libro se registró correctamente con el ID " + nuevoId + ".",
                    "Libro agregado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btActualizar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un libro de la tabla para actualizar su cantidad.",
                    "Ningún libro seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos(false))
            {
                return;
            }

            try
            {
                int cantidad = int.Parse(tbCantidad.Text.Trim());
                _logica.ActualizarCantidad(_idSeleccionado, cantidad);

                MessageBox.Show(
                    "La cantidad disponible se actualizó correctamente.",
                    "Libro actualizado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado <= 0)
            {
                MessageBox.Show(
                    "Seleccione un libro de la tabla para eliminarlo.",
                    "Ningún libro seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "¿Está seguro de que desea eliminar el libro \"" + tbTitulo.Text + "\"?\nEsta acción no se puede deshacer.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                return;
            }

            try
            {
                _logica.EliminarLibro(_idSeleccionado);

                MessageBox.Show(
                    "El libro se eliminó correctamente.",
                    "Libro eliminado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CargarLibros();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void btLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void chkSoloDisponibles_CheckedChanged(object sender, EventArgs e)
        {
            CargarLibros();
        }

        private void dgvLibros_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvLibros.SelectedRows.Count == 0)
            {
                return;
            }

            DataGridViewRow fila = dgvLibros.SelectedRows[0];

            _idSeleccionado = Convert.ToInt32(fila.Cells["id"].Value);
            tbTitulo.Text = Convert.ToString(fila.Cells["Titulo"].Value);
            tbAutor.Text = Convert.ToString(fila.Cells["Autor"].Value);
            tbCantidad.Text = Convert.ToString(fila.Cells["CantidadDisponible"].Value);
            tbTitulo.ReadOnly = true;
            tbAutor.ReadOnly = true;
            epValidacion.Clear();
            ActualizarEstadoBotones();
            tbCantidad.Focus();
        }

        private void Campos_TextChanged(object sender, EventArgs e)
        {
            if (sender is Control control)
            {
                epValidacion.SetError(control, string.Empty);
            }

            ActualizarEstadoBotones();
        }

        private void tbCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}