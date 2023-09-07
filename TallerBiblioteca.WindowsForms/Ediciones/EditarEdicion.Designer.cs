
namespace TallerBiblioteca.WindowsForms.Ediciones
{
    partial class EditarEdicion
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
            this.ucEdicion1 = new DatosEdicion();
            this.btnBuscarMetadatos = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucEdicion1
            // 
            this.ucEdicion1.Location = new System.Drawing.Point(31, 12);
            this.ucEdicion1.Name = "ucEdicion1";
            this.ucEdicion1.Size = new System.Drawing.Size(574, 365);
            this.ucEdicion1.TabIndex = 0;
            // 
            // btnBuscarMetadatos
            // 
            this.btnBuscarMetadatos.Location = new System.Drawing.Point(304, 27);
            this.btnBuscarMetadatos.Name = "btnBuscarMetadatos";
            this.btnBuscarMetadatos.Size = new System.Drawing.Size(72, 35);
            this.btnBuscarMetadatos.TabIndex = 18;
            this.btnBuscarMetadatos.Text = "Buscar metadatos";
            this.btnBuscarMetadatos.UseVisualStyleBackColor = true;
            this.btnBuscarMetadatos.Click += new System.EventHandler(this.btnBuscarMetadatos_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(391, 392);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(121, 392);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // EditarEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 434);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnBuscarMetadatos);
            this.Controls.Add(this.ucEdicion1);
            this.Name = "EditarEdicion";
            this.Text = "EditarEdicion";
            this.ResumeLayout(false);

        }

        #endregion

        private DatosEdicion ucEdicion1;
        private System.Windows.Forms.Button btnBuscarMetadatos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
    }
}