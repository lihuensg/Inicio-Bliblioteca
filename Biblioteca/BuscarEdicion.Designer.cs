
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
            this.lblISBN = new System.Windows.Forms.Label();
            this.textISBN = new System.Windows.Forms.TextBox();
            this.btnBuscarISBN = new System.Windows.Forms.Button();
            this.dgvEdicion = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DNI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDeRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Puntaje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPublicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdicion)).BeginInit();
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
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
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
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(222, 26);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(32, 13);
            this.lblISBN.TabIndex = 3;
            this.lblISBN.Text = "ISBN";
            // 
            // textISBN
            // 
            this.textISBN.Location = new System.Drawing.Point(265, 23);
            this.textISBN.Name = "textISBN";
            this.textISBN.Size = new System.Drawing.Size(100, 20);
            this.textISBN.TabIndex = 4;
            // 
            // btnBuscarISBN
            // 
            this.btnBuscarISBN.Location = new System.Drawing.Point(276, 61);
            this.btnBuscarISBN.Name = "btnBuscarISBN";
            this.btnBuscarISBN.Size = new System.Drawing.Size(71, 23);
            this.btnBuscarISBN.TabIndex = 5;
            this.btnBuscarISBN.Text = "Buscar ";
            this.btnBuscarISBN.UseVisualStyleBackColor = true;
            this.btnBuscarISBN.Click += new System.EventHandler(this.btnBuscarISBN_Click);
            // 
            // dgvEdicion
            // 
            this.dgvEdicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEdicion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.DNI,
            this.FechaDeRegistro,
            this.Puntaje,
            this.FechaPublicacion});
            this.dgvEdicion.Location = new System.Drawing.Point(37, 106);
            this.dgvEdicion.Name = "dgvEdicion";
            this.dgvEdicion.Size = new System.Drawing.Size(539, 128);
            this.dgvEdicion.TabIndex = 9;
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
            this.Controls.Add(this.dgvEdicion);
            this.Controls.Add(this.btnBuscarISBN);
            this.Controls.Add(this.textISBN);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "BuscarEdicion";
            this.Text = "BuscarEdicion";
            ((System.ComponentModel.ISupportInitialize)(this.dgvEdicion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox textISBN;
        private System.Windows.Forms.Button btnBuscarISBN;
        private System.Windows.Forms.DataGridView dgvEdicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn DNI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Puntaje;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPublicacion;
    }
}