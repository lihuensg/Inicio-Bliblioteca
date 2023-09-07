
using TallerBiblioteca.WindowsForms.Ediciones;

namespace TallerBiblioteca.WindowsForms
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
            this.components = new System.ComponentModel.Container();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnBuscarMetadatos = new System.Windows.Forms.Button();
            this.tltMetadatos = new System.Windows.Forms.ToolTip(this.components);
            this.ucEdicion1 = new DatosEdicion();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(394, 375);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(124, 375);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscarMetadatos
            // 
            this.btnBuscarMetadatos.Location = new System.Drawing.Point(305, 23);
            this.btnBuscarMetadatos.Name = "btnBuscarMetadatos";
            this.btnBuscarMetadatos.Size = new System.Drawing.Size(72, 35);
            this.btnBuscarMetadatos.TabIndex = 17;
            this.btnBuscarMetadatos.Text = "Buscar metadatos";
            this.btnBuscarMetadatos.UseVisualStyleBackColor = true;
            this.btnBuscarMetadatos.Click += new System.EventHandler(this.btnBuscarMetadatos_Click);
            // 
            // tltMetadatos
            // 
            this.tltMetadatos.ToolTipTitle = "Busca los metadatos online para el ISBN ingresado y sobrescribe los campos.";
            // 
            // ucEdicion1
            // 
            this.ucEdicion1.Location = new System.Drawing.Point(25, 12);
            this.ucEdicion1.Name = "ucEdicion1";
            this.ucEdicion1.Size = new System.Drawing.Size(572, 357);
            this.ucEdicion1.TabIndex = 16;
            // 
            // CrearEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 432);
            this.Controls.Add(this.btnBuscarMetadatos);
            this.Controls.Add(this.ucEdicion1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Name = "CrearEdicion";
            this.Text = "Crear Edicion";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private DatosEdicion ucEdicion1;
        private System.Windows.Forms.Button btnBuscarMetadatos;
        private System.Windows.Forms.ToolTip tltMetadatos;
    }
}