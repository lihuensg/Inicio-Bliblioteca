
namespace Inicio_Bliblioteca
{
    partial class RegistrarPrestamos
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
            this.btnBusUsuario = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.btnEjemplar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCodigoInventario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFechaVencimiento = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBusUsuario
            // 
            this.btnBusUsuario.Location = new System.Drawing.Point(96, 74);
            this.btnBusUsuario.Name = "btnBusUsuario";
            this.btnBusUsuario.Size = new System.Drawing.Size(210, 44);
            this.btnBusUsuario.TabIndex = 0;
            this.btnBusUsuario.Text = "Buscar Usuario";
            this.btnBusUsuario.UseVisualStyleBackColor = true;
            this.btnBusUsuario.Click += new System.EventHandler(this.btnBusUsuario_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(154, 138);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.ReadOnly = true;
            this.txtDNI.Size = new System.Drawing.Size(100, 20);
            this.txtDNI.TabIndex = 2;
            // 
            // btnEjemplar
            // 
            this.btnEjemplar.Location = new System.Drawing.Point(475, 74);
            this.btnEjemplar.Name = "btnEjemplar";
            this.btnEjemplar.Size = new System.Drawing.Size(210, 44);
            this.btnEjemplar.TabIndex = 3;
            this.btnEjemplar.Text = "Buscar Ejemplar";
            this.btnEjemplar.UseVisualStyleBackColor = true;
            this.btnEjemplar.Click += new System.EventHandler(this.btnBuscarEjemplar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(478, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Codigo inventario:";
            // 
            // txtCodigoInventario
            // 
            this.txtCodigoInventario.Location = new System.Drawing.Point(585, 142);
            this.txtCodigoInventario.Name = "txtCodigoInventario";
            this.txtCodigoInventario.ReadOnly = true;
            this.txtCodigoInventario.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoInventario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Fecha de vencimiento maxima";
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.Location = new System.Drawing.Point(407, 226);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.ReadOnly = true;
            this.txtFechaVencimiento.Size = new System.Drawing.Size(112, 20);
            this.txtFechaVencimiento.TabIndex = 7;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(154, 329);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 8;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(536, 329);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // RegistrarPrestamos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtFechaVencimiento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCodigoInventario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnEjemplar);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBusUsuario);
            this.Name = "RegistrarPrestamos";
            this.Text = "RegistrarPrestamos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBusUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Button btnEjemplar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoInventario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFechaVencimiento;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}