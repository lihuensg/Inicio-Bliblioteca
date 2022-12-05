
namespace Inicio_Bliblioteca
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.PrestamosVencimiento = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lUsuarios = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usuarios1 = new Inicio_Bliblioteca.Usuarios();
            this.prestamosYDevoluciones1 = new Inicio_Bliblioteca.PrestamosYDevoluciones();
            this.prestamosProxVencer1 = new Inicio_Bliblioteca.PrestamosProxVencer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ejemplares1 = new Inicio_Bliblioteca.Ejemplares();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 454);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Controls.Add(this.PrestamosVencimiento);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(12, 264);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(155, 32);
            this.panel4.TabIndex = 5;
            // 
            // PrestamosVencimiento
            // 
            this.PrestamosVencimiento.AutoSize = true;
            this.PrestamosVencimiento.Location = new System.Drawing.Point(4, 9);
            this.PrestamosVencimiento.Name = "PrestamosVencimiento";
            this.PrestamosVencimiento.Size = new System.Drawing.Size(145, 13);
            this.PrestamosVencimiento.TabIndex = 2;
            this.PrestamosVencimiento.Text = "Prestamos proximos a vencer";
            this.PrestamosVencimiento.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel3.Location = new System.Drawing.Point(12, 155);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(149, 32);
            this.panel3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prestamos y Devoluciones";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.lUsuarios);
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(35, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(100, 32);
            this.panel2.TabIndex = 5;
            // 
            // lUsuarios
            // 
            this.lUsuarios.AutoSize = true;
            this.lUsuarios.Location = new System.Drawing.Point(24, 10);
            this.lUsuarios.Name = "lUsuarios";
            this.lUsuarios.Size = new System.Drawing.Size(51, 13);
            this.lUsuarios.TabIndex = 0;
            this.lUsuarios.Text = " Usuarios";
            this.lUsuarios.Click += new System.EventHandler(this.lUsuarios_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 3;
            // 
            // usuarios1
            // 
            this.usuarios1.Location = new System.Drawing.Point(211, 34);
            this.usuarios1.Name = "usuarios1";
            this.usuarios1.Size = new System.Drawing.Size(623, 395);
            this.usuarios1.TabIndex = 2;
            // 
            // prestamosYDevoluciones1
            // 
            this.prestamosYDevoluciones1.Location = new System.Drawing.Point(211, 34);
            this.prestamosYDevoluciones1.Name = "prestamosYDevoluciones1";
            this.prestamosYDevoluciones1.Size = new System.Drawing.Size(623, 395);
            this.prestamosYDevoluciones1.TabIndex = 3;
            // 
            // prestamosProxVencer1
            // 
            this.prestamosProxVencer1.Location = new System.Drawing.Point(211, 17);
            this.prestamosProxVencer1.Name = "prestamosProxVencer1";
            this.prestamosProxVencer1.Size = new System.Drawing.Size(623, 395);
            this.prestamosProxVencer1.TabIndex = 4;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(35, 371);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(100, 32);
            this.panel5.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ejemplares";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ejemplares1
            // 
            this.ejemplares1.Location = new System.Drawing.Point(211, 34);
            this.ejemplares1.Name = "ejemplares1";
            this.ejemplares1.Size = new System.Drawing.Size(623, 395);
            this.ejemplares1.TabIndex = 5;
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(889, 454);
            this.Controls.Add(this.ejemplares1);
            this.Controls.Add(this.prestamosProxVencer1);
            this.Controls.Add(this.prestamosYDevoluciones1);
            this.Controls.Add(this.usuarios1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Usuario";
            this.Text = "Usuario Biblioteca";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lUsuarios;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label PrestamosVencimiento;
        private System.Windows.Forms.Label label2;
        private Usuarios usuarios1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private PrestamosYDevoluciones prestamosYDevoluciones1;
        private PrestamosProxVencer prestamosProxVencer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private Ejemplares ejemplares1;
    }
}