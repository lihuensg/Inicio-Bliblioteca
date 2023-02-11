
namespace Inicio_Bliblioteca
{
    partial class RegistrarDevolucion
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
            this.textCodigoInventario = new System.Windows.Forms.TextBox();
            this.btnBuscarCodInv = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxMalEstado = new System.Windows.Forms.CheckBox();
            this.btnDevolver = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textCodigoInventario
            // 
            this.textCodigoInventario.Location = new System.Drawing.Point(36, 57);
            this.textCodigoInventario.Name = "textCodigoInventario";
            this.textCodigoInventario.Size = new System.Drawing.Size(146, 20);
            this.textCodigoInventario.TabIndex = 1;
            // 
            // btnBuscarCodInv
            // 
            this.btnBuscarCodInv.Location = new System.Drawing.Point(207, 55);
            this.btnBuscarCodInv.Name = "btnBuscarCodInv";
            this.btnBuscarCodInv.Size = new System.Drawing.Size(71, 23);
            this.btnBuscarCodInv.TabIndex = 2;
            this.btnBuscarCodInv.Text = "Buscar";
            this.btnBuscarCodInv.UseVisualStyleBackColor = true;
            this.btnBuscarCodInv.Click += new System.EventHandler(this.btnBuscarCodInv_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese Codigo Inventario";
            // 
            // checkBoxMalEstado
            // 
            this.checkBoxMalEstado.AutoSize = true;
            this.checkBoxMalEstado.Location = new System.Drawing.Point(36, 108);
            this.checkBoxMalEstado.Name = "checkBoxMalEstado";
            this.checkBoxMalEstado.Size = new System.Drawing.Size(159, 17);
            this.checkBoxMalEstado.TabIndex = 4;
            this.checkBoxMalEstado.Text = "Se encontro en MAL estado";
            this.checkBoxMalEstado.UseVisualStyleBackColor = true;
            // 
            // btnDevolver
            // 
            this.btnDevolver.Enabled = false;
            this.btnDevolver.Location = new System.Drawing.Point(36, 168);
            this.btnDevolver.Name = "btnDevolver";
            this.btnDevolver.Size = new System.Drawing.Size(71, 23);
            this.btnDevolver.TabIndex = 5;
            this.btnDevolver.Text = "Devolver";
            this.btnDevolver.UseVisualStyleBackColor = true;
            this.btnDevolver.Click += new System.EventHandler(this.btnDevolver_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(181, 168);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(71, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // RegistrarDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 295);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnDevolver);
            this.Controls.Add(this.checkBoxMalEstado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscarCodInv);
            this.Controls.Add(this.textCodigoInventario);
            this.Name = "RegistrarDevolucion";
            this.Text = "RegistrarDevolucion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textCodigoInventario;
        private System.Windows.Forms.Button btnBuscarCodInv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxMalEstado;
        private System.Windows.Forms.Button btnDevolver;
        private System.Windows.Forms.Button btnCancelar;
    }
}