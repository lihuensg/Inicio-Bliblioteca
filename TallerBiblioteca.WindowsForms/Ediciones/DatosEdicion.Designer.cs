
namespace TallerBiblioteca.WindowsForms.Ediciones
{
    partial class DatosEdicion
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtISBNEdicion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAutores = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbPortada = new System.Windows.Forms.PictureBox();
            this.numAñoEdicion = new System.Windows.Forms.NumericUpDown();
            this.numNumeroPaginas = new System.Windows.Forms.NumericUpDown();
            this.txtDatosAdicionales = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPortada = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEditorial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPortada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAñoEdicion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroPaginas)).BeginInit();
            this.SuspendLayout();
            // 
            // txtISBNEdicion
            // 
            this.txtISBNEdicion.Location = new System.Drawing.Point(125, 18);
            this.txtISBNEdicion.Name = "txtISBNEdicion";
            this.txtISBNEdicion.Size = new System.Drawing.Size(145, 20);
            this.txtISBNEdicion.TabIndex = 40;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(84, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 39;
            this.label10.Text = "ISBN:";
            // 
            // txtAutores
            // 
            this.txtAutores.Location = new System.Drawing.Point(125, 166);
            this.txtAutores.Name = "txtAutores";
            this.txtAutores.Size = new System.Drawing.Size(200, 20);
            this.txtAutores.TabIndex = 37;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(73, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Autores:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(125, 202);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(200, 51);
            this.txtDescripcion.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "Descripción:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(125, 57);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(200, 20);
            this.txtTitulo.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(81, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Título:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(357, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Portada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Número de Páginas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Año Edicion:";
            // 
            // pbPortada
            // 
            this.pbPortada.Location = new System.Drawing.Point(360, 27);
            this.pbPortada.Name = "pbPortada";
            this.pbPortada.Size = new System.Drawing.Size(200, 285);
            this.pbPortada.TabIndex = 31;
            this.pbPortada.TabStop = false;
            // 
            // numAñoEdicion
            // 
            this.numAñoEdicion.Location = new System.Drawing.Point(125, 96);
            this.numAñoEdicion.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numAñoEdicion.Name = "numAñoEdicion";
            this.numAñoEdicion.Size = new System.Drawing.Size(200, 20);
            this.numAñoEdicion.TabIndex = 42;
            // 
            // numNumeroPaginas
            // 
            this.numNumeroPaginas.Location = new System.Drawing.Point(125, 131);
            this.numNumeroPaginas.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numNumeroPaginas.Name = "numNumeroPaginas";
            this.numNumeroPaginas.Size = new System.Drawing.Size(200, 20);
            this.numNumeroPaginas.TabIndex = 43;
            // 
            // txtDatosAdicionales
            // 
            this.txtDatosAdicionales.Location = new System.Drawing.Point(125, 304);
            this.txtDatosAdicionales.Multiline = true;
            this.txtDatosAdicionales.Name = "txtDatosAdicionales";
            this.txtDatosAdicionales.Size = new System.Drawing.Size(200, 34);
            this.txtDatosAdicionales.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 46;
            this.label2.Text = "Datos adicionales:";
            // 
            // txtPortada
            // 
            this.txtPortada.Location = new System.Drawing.Point(360, 318);
            this.txtPortada.Name = "txtPortada";
            this.txtPortada.Size = new System.Drawing.Size(200, 20);
            this.txtPortada.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 273);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 49;
            this.label1.Text = "Datos de editorial:";
            // 
            // txtEditorial
            // 
            this.txtEditorial.Location = new System.Drawing.Point(125, 270);
            this.txtEditorial.Name = "txtEditorial";
            this.txtEditorial.Size = new System.Drawing.Size(200, 20);
            this.txtEditorial.TabIndex = 50;
            // 
            // ucEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEditorial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPortada);
            this.Controls.Add(this.txtDatosAdicionales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numNumeroPaginas);
            this.Controls.Add(this.numAñoEdicion);
            this.Controls.Add(this.txtISBNEdicion);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtAutores);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbPortada);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "ucEdicion";
            this.Size = new System.Drawing.Size(574, 365);
            ((System.ComponentModel.ISupportInitialize)(this.pbPortada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAñoEdicion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numNumeroPaginas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtISBNEdicion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAutores;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pbPortada;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numAñoEdicion;
        private System.Windows.Forms.NumericUpDown numNumeroPaginas;
        private System.Windows.Forms.TextBox txtDatosAdicionales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPortada;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEditorial;
    }
}
