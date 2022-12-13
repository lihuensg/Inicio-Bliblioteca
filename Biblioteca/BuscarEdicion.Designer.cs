
namespace Inicio_Bliblioteca
{
    partial class BuscarEdicion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblObra = new System.Windows.Forms.Label();
            this.textObra = new System.Windows.Forms.TextBox();
            this.btnBuscarObra = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDeRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(129, 283);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(405, 283);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblObra
            // 
            this.lblObra.AutoSize = true;
            this.lblObra.Location = new System.Drawing.Point(222, 26);
            this.lblObra.Name = "lblObra";
            this.lblObra.Size = new System.Drawing.Size(37, 13);
            this.lblObra.TabIndex = 3;
            this.lblObra.Text = "OBRA";
            // 
            // textObra
            // 
            this.textObra.Location = new System.Drawing.Point(265, 23);
            this.textObra.Name = "textObra";
            this.textObra.ReadOnly = true;
            this.textObra.Size = new System.Drawing.Size(100, 20);
            this.textObra.TabIndex = 4;
            // 
            // btnBuscarObra
            // 
            this.btnBuscarObra.Location = new System.Drawing.Point(276, 61);
            this.btnBuscarObra.Name = "btnBuscarObra";
            this.btnBuscarObra.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarObra.TabIndex = 5;
            this.btnBuscarObra.Text = "Buscar Obra";
            this.btnBuscarObra.UseVisualStyleBackColor = true;
            this.btnBuscarObra.Click += new System.EventHandler(this.btnBuscarObra_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.DNI,
            this.FechaDeRegistro,
            this.Puntaje,
            this.FechaPublicacion});
            this.dgvUsuarios.Location = new System.Drawing.Point(37, 106);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(539, 128);
            this.dgvUsuarios.TabIndex = 9;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "ISBN";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // DNI
            // 
            this.DNI.HeaderText = "Año Edicion";
            this.DNI.Name = "DNI";
            this.DNI.ReadOnly = true;
            // 
            // FechaDeRegistro
            // 
            this.FechaDeRegistro.HeaderText = "Numero paginas";
            this.FechaDeRegistro.Name = "FechaDeRegistro";
            this.FechaDeRegistro.ReadOnly = true;
            // 
            // Puntaje
            // 
            this.Puntaje.HeaderText = "Portada";
            this.Puntaje.Name = "Puntaje";
            this.Puntaje.ReadOnly = true;
            // 
            // FechaPublicacion
            // 
            this.FechaPublicacion.HeaderText = "Fecha Publicacion";
            this.FechaPublicacion.Name = "FechaPublicacion";
            this.FechaPublicacion.ReadOnly = true;
            // 
            // BuscarEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 356);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btnBuscarObra);
            this.Controls.Add(this.textObra);
            this.Controls.Add(this.lblObra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "BuscarEdicion";
            this.Text = "BuscarEdicion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblObra;
        private System.Windows.Forms.TextBox textObra;
        private System.Windows.Forms.Button btnBuscarObra;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPublicacion;
    }
}