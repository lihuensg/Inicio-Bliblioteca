
namespace Inicio_Bliblioteca
{
    partial class CrearEdicion
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textISBN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textAñoEdicion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textNumeroPaginas = new System.Windows.Forms.TextBox();
            this.textFechaPublicacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnBuscarEdicion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(426, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(183, 267);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "INGRESE:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "ISBN:";
            // 
            // textISBN
            // 
            this.textISBN.Location = new System.Drawing.Point(77, 56);
            this.textISBN.Name = "textISBN";
            this.textISBN.Size = new System.Drawing.Size(100, 20);
            this.textISBN.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Año Edicion:";
            // 
            // textAñoEdicion
            // 
            this.textAñoEdicion.Location = new System.Drawing.Point(343, 52);
            this.textAñoEdicion.Name = "textAñoEdicion";
            this.textAñoEdicion.ReadOnly = true;
            this.textAñoEdicion.Size = new System.Drawing.Size(100, 20);
            this.textAñoEdicion.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Número Páginas:";
            // 
            // textNumeroPaginas
            // 
            this.textNumeroPaginas.Location = new System.Drawing.Point(343, 92);
            this.textNumeroPaginas.Name = "textNumeroPaginas";
            this.textNumeroPaginas.ReadOnly = true;
            this.textNumeroPaginas.Size = new System.Drawing.Size(100, 20);
            this.textNumeroPaginas.TabIndex = 10;
            // 
            // textFechaPublicacion
            // 
            this.textFechaPublicacion.Location = new System.Drawing.Point(343, 132);
            this.textFechaPublicacion.Name = "textFechaPublicacion";
            this.textFechaPublicacion.ReadOnly = true;
            this.textFechaPublicacion.Size = new System.Drawing.Size(100, 20);
            this.textFechaPublicacion.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(239, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fecha Publicación:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(498, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Portada:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(501, 68);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 169);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // btnBuscarEdicion
            // 
            this.btnBuscarEdicion.Location = new System.Drawing.Point(77, 90);
            this.btnBuscarEdicion.Name = "btnBuscarEdicion";
            this.btnBuscarEdicion.Size = new System.Drawing.Size(100, 23);
            this.btnBuscarEdicion.TabIndex = 15;
            this.btnBuscarEdicion.Text = "Buscar Edición";
            this.btnBuscarEdicion.UseVisualStyleBackColor = true;
            this.btnBuscarEdicion.Click += new System.EventHandler(this.btnBuscarEdicion_Click);
            // 
            // CrearEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 302);
            this.Controls.Add(this.btnBuscarEdicion);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textFechaPublicacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNumeroPaginas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textAñoEdicion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textISBN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Name = "CrearEdicion";
            this.Text = "CrearEdicion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textISBN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textAñoEdicion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textNumeroPaginas;
        private System.Windows.Forms.TextBox textFechaPublicacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnBuscarEdicion;
    }
}