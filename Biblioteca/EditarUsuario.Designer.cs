
namespace Inicio_Bliblioteca
{
    partial class EditarUsuario
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReinicioContraseña = new System.Windows.Forms.Button();
            this.btnCambioContraseña = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(150, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 152);
            this.panel1.TabIndex = 12;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(182, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(182, 91);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(261, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mail";
            // 
            // btnReinicioContraseña
            // 
            this.btnReinicioContraseña.Location = new System.Drawing.Point(508, 301);
            this.btnReinicioContraseña.Name = "btnReinicioContraseña";
            this.btnReinicioContraseña.Size = new System.Drawing.Size(152, 24);
            this.btnReinicioContraseña.TabIndex = 11;
            this.btnReinicioContraseña.Text = "Reiniciar contraseña";
            this.btnReinicioContraseña.UseVisualStyleBackColor = true;
            // 
            // btnCambioContraseña
            // 
            this.btnCambioContraseña.Location = new System.Drawing.Point(295, 301);
            this.btnCambioContraseña.Name = "btnCambioContraseña";
            this.btnCambioContraseña.Size = new System.Drawing.Size(152, 24);
            this.btnCambioContraseña.TabIndex = 10;
            this.btnCambioContraseña.Text = "Cambiar contraseña";
            this.btnCambioContraseña.UseVisualStyleBackColor = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(163, 301);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 24);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // EditarUsuario1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReinicioContraseña);
            this.Controls.Add(this.btnCambioContraseña);
            this.Controls.Add(this.btnAceptar);
            this.Name = "EditarUsuario1";
            this.Text = "EditarUsuario1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReinicioContraseña;
        private System.Windows.Forms.Button btnCambioContraseña;
        private System.Windows.Forms.Button btnAceptar;
    }
}