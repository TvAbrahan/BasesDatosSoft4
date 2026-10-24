namespace Lab6_Libreria
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbEncabezado = new System.Windows.Forms.Label();
            this.gbDatos = new System.Windows.Forms.GroupBox();
            this.tbCantidad = new System.Windows.Forms.TextBox();
            this.lbCantidad = new System.Windows.Forms.Label();
            this.tbAutor = new System.Windows.Forms.TextBox();
            this.lbAutor = new System.Windows.Forms.Label();
            this.tbTitulo = new System.Windows.Forms.TextBox();
            this.lbTituloLibro = new System.Windows.Forms.Label();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.btLimpiar = new System.Windows.Forms.Button();
            this.btEliminar = new System.Windows.Forms.Button();
            this.btActualizar = new System.Windows.Forms.Button();
            this.btAgregar = new System.Windows.Forms.Button();
            this.lbLista = new System.Windows.Forms.Label();
            this.chkSoloDisponibles = new System.Windows.Forms.CheckBox();
            this.dgvLibros = new System.Windows.Forms.DataGridView();
            this.epValidacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDatos.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epValidacion)).BeginInit();
            this.SuspendLayout();
            // 
            // lbEncabezado
            // 
            this.lbEncabezado.AutoSize = true;
            this.lbEncabezado.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lbEncabezado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(56)))), ((int)(((byte)(100)))));
            this.lbEncabezado.Location = new System.Drawing.Point(17, 10);
            this.lbEncabezado.Name = "lbEncabezado";
            this.lbEncabezado.Size = new System.Drawing.Size(261, 32);
            this.lbEncabezado.TabIndex = 0;
            this.lbEncabezado.Text = "Inventario de Librería";
            // 
            // gbDatos
            // 
            this.gbDatos.Controls.Add(this.tbCantidad);
            this.gbDatos.Controls.Add(this.lbCantidad);
            this.gbDatos.Controls.Add(this.tbAutor);
            this.gbDatos.Controls.Add(this.lbAutor);
            this.gbDatos.Controls.Add(this.tbTitulo);
            this.gbDatos.Controls.Add(this.lbTituloLibro);
            this.gbDatos.Location = new System.Drawing.Point(17, 52);
            this.gbDatos.Name = "gbDatos";
            this.gbDatos.Size = new System.Drawing.Size(257, 243);
            this.gbDatos.TabIndex = 1;
            this.gbDatos.TabStop = false;
            this.gbDatos.Text = "Datos del libro";
            // 
            // tbCantidad
            // 
            this.tbCantidad.Location = new System.Drawing.Point(13, 186);
            this.tbCantidad.MaxLength = 9;
            this.tbCantidad.Name = "tbCantidad";
            this.tbCantidad.Size = new System.Drawing.Size(112, 20);
            this.tbCantidad.TabIndex = 5;
            this.tbCantidad.TextChanged += new System.EventHandler(this.Campos_TextChanged);
            this.tbCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbCantidad_KeyPress);
            // 
            // lbCantidad
            // 
            this.lbCantidad.AutoSize = true;
            this.lbCantidad.Location = new System.Drawing.Point(13, 167);
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(99, 13);
            this.lbCantidad.TabIndex = 4;
            this.lbCantidad.Text = "Cantidad disponible";
            // 
            // tbAutor
            // 
            this.tbAutor.Location = new System.Drawing.Point(13, 121);
            this.tbAutor.MaxLength = 150;
            this.tbAutor.Name = "tbAutor";
            this.tbAutor.Size = new System.Drawing.Size(232, 20);
            this.tbAutor.TabIndex = 3;
            this.tbAutor.TextChanged += new System.EventHandler(this.Campos_TextChanged);
            // 
            // lbAutor
            // 
            this.lbAutor.AutoSize = true;
            this.lbAutor.Location = new System.Drawing.Point(13, 102);
            this.lbAutor.Name = "lbAutor";
            this.lbAutor.Size = new System.Drawing.Size(32, 13);
            this.lbAutor.TabIndex = 2;
            this.lbAutor.Text = "Autor";
            // 
            // tbTitulo
            // 
            this.tbTitulo.Location = new System.Drawing.Point(13, 56);
            this.tbTitulo.MaxLength = 200;
            this.tbTitulo.Name = "tbTitulo";
            this.tbTitulo.Size = new System.Drawing.Size(232, 20);
            this.tbTitulo.TabIndex = 1;
            this.tbTitulo.TextChanged += new System.EventHandler(this.Campos_TextChanged);
            // 
            // lbTituloLibro
            // 
            this.lbTituloLibro.AutoSize = true;
            this.lbTituloLibro.Location = new System.Drawing.Point(13, 37);
            this.lbTituloLibro.Name = "lbTituloLibro";
            this.lbTituloLibro.Size = new System.Drawing.Size(35, 13);
            this.lbTituloLibro.TabIndex = 0;
            this.lbTituloLibro.Text = "Título";
            // 
            // gbAcciones
            // 
            this.gbAcciones.Controls.Add(this.btLimpiar);
            this.gbAcciones.Controls.Add(this.btEliminar);
            this.gbAcciones.Controls.Add(this.btActualizar);
            this.gbAcciones.Controls.Add(this.btAgregar);
            this.gbAcciones.Location = new System.Drawing.Point(17, 308);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(257, 126);
            this.gbAcciones.TabIndex = 2;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // btLimpiar
            // 
            this.btLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLimpiar.ForeColor = System.Drawing.Color.White;
            this.btLimpiar.Location = new System.Drawing.Point(133, 74);
            this.btLimpiar.Name = "btLimpiar";
            this.btLimpiar.Size = new System.Drawing.Size(111, 35);
            this.btLimpiar.TabIndex = 3;
            this.btLimpiar.Text = "Limpiar";
            this.btLimpiar.UseVisualStyleBackColor = false;
            this.btLimpiar.Click += new System.EventHandler(this.btLimpiar_Click);
            // 
            // btEliminar
            // 
            this.btEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btEliminar.ForeColor = System.Drawing.Color.White;
            this.btEliminar.Location = new System.Drawing.Point(13, 74);
            this.btEliminar.Name = "btEliminar";
            this.btEliminar.Size = new System.Drawing.Size(111, 35);
            this.btEliminar.TabIndex = 2;
            this.btEliminar.Text = "Eliminar";
            this.btEliminar.UseVisualStyleBackColor = false;
            this.btEliminar.Click += new System.EventHandler(this.btEliminar_Click);
            // 
            // btActualizar
            // 
            this.btActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(117)))), ((int)(((byte)(182)))));
            this.btActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btActualizar.ForeColor = System.Drawing.Color.White;
            this.btActualizar.Location = new System.Drawing.Point(133, 26);
            this.btActualizar.Name = "btActualizar";
            this.btActualizar.Size = new System.Drawing.Size(111, 35);
            this.btActualizar.TabIndex = 1;
            this.btActualizar.Text = "Actualizar";
            this.btActualizar.UseVisualStyleBackColor = false;
            this.btActualizar.Click += new System.EventHandler(this.btActualizar_Click);
            // 
            // btAgregar
            // 
            this.btAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(148)))), ((int)(((byte)(91)))));
            this.btAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btAgregar.ForeColor = System.Drawing.Color.White;
            this.btAgregar.Location = new System.Drawing.Point(13, 26);
            this.btAgregar.Name = "btAgregar";
            this.btAgregar.Size = new System.Drawing.Size(111, 35);
            this.btAgregar.TabIndex = 0;
            this.btAgregar.Text = "Agregar";
            this.btAgregar.UseVisualStyleBackColor = false;
            this.btAgregar.Click += new System.EventHandler(this.btAgregar_Click);
            // 
            // lbLista
            // 
            this.lbLista.AutoSize = true;
            this.lbLista.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbLista.Location = new System.Drawing.Point(291, 57);
            this.lbLista.Name = "lbLista";
            this.lbLista.Size = new System.Drawing.Size(135, 20);
            this.lbLista.TabIndex = 3;
            this.lbLista.Text = "Libros registrados";
            // 
            // chkSoloDisponibles
            // 
            this.chkSoloDisponibles.AutoSize = true;
            this.chkSoloDisponibles.Location = new System.Drawing.Point(566, 59);
            this.chkSoloDisponibles.Name = "chkSoloDisponibles";
            this.chkSoloDisponibles.Size = new System.Drawing.Size(159, 17);
            this.chkSoloDisponibles.TabIndex = 4;
            this.chkSoloDisponibles.Text = "Mostrar solo con existencias";
            this.chkSoloDisponibles.UseVisualStyleBackColor = true;
            this.chkSoloDisponibles.CheckedChanged += new System.EventHandler(this.chkSoloDisponibles_CheckedChanged);
            // 
            // dgvLibros
            // 
            this.dgvLibros.AllowUserToAddRows = false;
            this.dgvLibros.AllowUserToDeleteRows = false;
            this.dgvLibros.AllowUserToResizeRows = false;
            this.dgvLibros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLibros.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLibros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLibros.Location = new System.Drawing.Point(291, 82);
            this.dgvLibros.MultiSelect = false;
            this.dgvLibros.Name = "dgvLibros";
            this.dgvLibros.ReadOnly = true;
            this.dgvLibros.RowHeadersVisible = false;
            this.dgvLibros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLibros.Size = new System.Drawing.Size(429, 351);
            this.dgvLibros.TabIndex = 5;
            this.dgvLibros.SelectionChanged += new System.EventHandler(this.dgvLibros_SelectionChanged);
            // 
            // epValidacion
            // 
            this.epValidacion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.epValidacion.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 451);
            this.Controls.Add(this.dgvLibros);
            this.Controls.Add(this.chkSoloDisponibles);
            this.Controls.Add(this.lbLista);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbDatos);
            this.Controls.Add(this.lbEncabezado);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrahan Tuñon (8-1025-1064), Moisés Murgas (8-1003-179) y Jorge Sarmiento (3-757-" +
    "1758)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbDatos.ResumeLayout(false);
            this.gbDatos.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLibros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epValidacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lbEncabezado;
        private System.Windows.Forms.GroupBox gbDatos;
        private System.Windows.Forms.TextBox tbCantidad;
        private System.Windows.Forms.Label lbCantidad;
        private System.Windows.Forms.TextBox tbAutor;
        private System.Windows.Forms.Label lbAutor;
        private System.Windows.Forms.TextBox tbTitulo;
        private System.Windows.Forms.Label lbTituloLibro;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.Button btLimpiar;
        private System.Windows.Forms.Button btEliminar;
        private System.Windows.Forms.Button btActualizar;
        private System.Windows.Forms.Button btAgregar;
        private System.Windows.Forms.Label lbLista;
        private System.Windows.Forms.CheckBox chkSoloDisponibles;
        private System.Windows.Forms.DataGridView dgvLibros;
        private System.Windows.Forms.ErrorProvider epValidacion;
    }
}