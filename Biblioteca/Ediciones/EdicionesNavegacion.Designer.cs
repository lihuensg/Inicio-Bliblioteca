
namespace Inicio_Bliblioteca.Ediciones {
    partial class EdicionesNavegacion {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnCrearEdicion = new System.Windows.Forms.Button();
            this.btnBuscarEdicion = new System.Windows.Forms.Button();
            this.btnEditarEdicion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearEdicion
            // 
            this.btnCrearEdicion.Location = new System.Drawing.Point(194, 20);
            this.btnCrearEdicion.Name = "btnCrearEdicion";
            this.btnCrearEdicion.Size = new System.Drawing.Size(214, 44);
            this.btnCrearEdicion.TabIndex = 0;
            this.btnCrearEdicion.Text = "Crear una edición";
            this.btnCrearEdicion.UseVisualStyleBackColor = true;
            this.btnCrearEdicion.Click += new System.EventHandler(this.btnCrearEdicion_Click);
            // 
            // btnBuscarEdicion
            // 
            this.btnBuscarEdicion.Location = new System.Drawing.Point(194, 179);
            this.btnBuscarEdicion.Name = "btnBuscarEdicion";
            this.btnBuscarEdicion.Size = new System.Drawing.Size(214, 44);
            this.btnBuscarEdicion.TabIndex = 1;
            this.btnBuscarEdicion.Text = "Buscar una edición";
            this.btnBuscarEdicion.UseVisualStyleBackColor = true;
            this.btnBuscarEdicion.Click += new System.EventHandler(this.btnBuscarEdicion_Click);
            // 
            // btnEditarEdicion
            // 
            this.btnEditarEdicion.Location = new System.Drawing.Point(194, 338);
            this.btnEditarEdicion.Name = "btnEditarEdicion";
            this.btnEditarEdicion.Size = new System.Drawing.Size(214, 44);
            this.btnEditarEdicion.TabIndex = 2;
            this.btnEditarEdicion.Text = "Editar una edición";
            this.btnEditarEdicion.UseVisualStyleBackColor = true;
            this.btnEditarEdicion.Click += new System.EventHandler(this.btnEditarEdicion_Click);
            // 
            // ucEdicionesNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditarEdicion);
            this.Controls.Add(this.btnBuscarEdicion);
            this.Controls.Add(this.btnCrearEdicion);
            this.Name = "ucEdicionesNav";
            this.Size = new System.Drawing.Size(623, 395);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearEdicion;
        private System.Windows.Forms.Button btnBuscarEdicion;
        private System.Windows.Forms.Button btnEditarEdicion;
    }
}
