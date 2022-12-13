
namespace Inicio_Bliblioteca
{
    partial class BuscarEjemplar
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
            this.btnSelcObra = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CodigoInv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prestado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaDeAlta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnRegistrarObra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelcObra
            // 
            this.btnSelcObra.Location = new System.Drawing.Point(438, 85);
            this.btnSelcObra.Name = "btnSelcObra";
            this.btnSelcObra.Size = new System.Drawing.Size(105, 21);
            this.btnSelcObra.TabIndex = 0;
            this.btnSelcObra.Text = "Seleccion de obra";
            this.btnSelcObra.UseVisualStyleBackColor = true;
            this.btnSelcObra.Click += new System.EventHandler(this.btnSelcObra_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoInv,
            this.Prestado,
            this.FechaDeAlta});
            this.dataGridView1.Location = new System.Drawing.Point(249, 133);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(325, 121);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // CodigoInv
            // 
            this.CodigoInv.HeaderText = "Codigo inventario";
            this.CodigoInv.Name = "CodigoInv";
            this.CodigoInv.ReadOnly = true;
            // 
            // Prestado
            // 
            this.Prestado.HeaderText = "Prestado actualmente";
            this.Prestado.Name = "Prestado";
            this.Prestado.ReadOnly = true;
            // 
            // FechaDeAlta
            // 
            this.FechaDeAlta.HeaderText = "Fecha de alta";
            this.FechaDeAlta.Name = "FechaDeAlta";
            this.FechaDeAlta.ReadOnly = true;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(317, 86);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(100, 20);
            this.txtTitulo.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "TITULO:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(515, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(231, 353);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 10;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnRegistrarObra
            // 
            this.btnRegistrarObra.Location = new System.Drawing.Point(346, 269);
            this.btnRegistrarObra.Name = "btnRegistrarObra";
            this.btnRegistrarObra.Size = new System.Drawing.Size(125, 40);
            this.btnRegistrarObra.TabIndex = 13;
            this.btnRegistrarObra.Text = "Registrar obra desde libreria";
            this.btnRegistrarObra.UseVisualStyleBackColor = true;
            // 
            // BuscarEjemplar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRegistrarObra);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSelcObra);
            this.Name = "BuscarEjemplar";
            this.Text = "BuscarEjemplar";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelcObra;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoInv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prestado;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaDeAlta;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnRegistrarObra;
    }
}