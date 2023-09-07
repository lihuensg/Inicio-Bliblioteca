
namespace TallerBiblioteca.WindowsForms
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
            this.lblISBN = new System.Windows.Forms.Label();
            this.textISBN = new System.Windows.Forms.TextBox();
            this.btnBuscarISBN = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.ucEdicion1 = new Ediciones.DatosEdicion();
            this.SuspendLayout();
            // 
            // lblISBN
            // 
            this.lblISBN.AutoSize = true;
            this.lblISBN.Location = new System.Drawing.Point(61, 18);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new System.Drawing.Size(125, 13);
            this.lblISBN.TabIndex = 3;
            this.lblISBN.Text = "Ingrese el ISBN a buscar";
            // 
            // textISBN
            // 
            this.textISBN.Location = new System.Drawing.Point(216, 15);
            this.textISBN.Name = "textISBN";
            this.textISBN.Size = new System.Drawing.Size(167, 20);
            this.textISBN.TabIndex = 4;
            // 
            // btnBuscarISBN
            // 
            this.btnBuscarISBN.Location = new System.Drawing.Point(413, 12);
            this.btnBuscarISBN.Name = "btnBuscarISBN";
            this.btnBuscarISBN.Size = new System.Drawing.Size(71, 23);
            this.btnBuscarISBN.TabIndex = 5;
            this.btnBuscarISBN.Text = "Buscar ";
            this.btnBuscarISBN.UseVisualStyleBackColor = true;
            this.btnBuscarISBN.Click += new System.EventHandler(this.btnBuscarISBN_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnEditar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEditar.Location = new System.Drawing.Point(529, 425);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(81, 23);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar datos";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // ucEdicion1
            // 
            this.ucEdicion1.BackColor = System.Drawing.SystemColors.Control;
            this.ucEdicion1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucEdicion1.Location = new System.Drawing.Point(27, 53);
            this.ucEdicion1.Name = "ucEdicion1";
            this.ucEdicion1.Size = new System.Drawing.Size(583, 366);
            this.ucEdicion1.TabIndex = 6;
            // 
            // BuscarEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 486);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.ucEdicion1);
            this.Controls.Add(this.btnBuscarISBN);
            this.Controls.Add(this.textISBN);
            this.Controls.Add(this.lblISBN);
            this.Name = "BuscarEdicion";
            this.Text = "Buscar Edicion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblISBN;
        private System.Windows.Forms.TextBox textISBN;
        private System.Windows.Forms.Button btnBuscarISBN;
        private Ediciones.DatosEdicion ucEdicion1;
        private System.Windows.Forms.Button btnEditar;
    }
}