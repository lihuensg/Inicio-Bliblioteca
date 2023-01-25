
namespace Inicio_Bliblioteca
{
    partial class AgregarEdicionRemota
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Añoedicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeropaginas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaedicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obratitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.btnAgregarTodos = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ISBN,
            this.Añoedicion,
            this.numeropaginas,
            this.fechaedicion,
            this.obratitulo,
            this.portada});
            this.dataGridView1.Location = new System.Drawing.Point(29, 84);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(746, 198);
            this.dataGridView1.TabIndex = 15;
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            // 
            // Añoedicion
            // 
            this.Añoedicion.HeaderText = "Año edicion";
            this.Añoedicion.Name = "Añoedicion";
            // 
            // numeropaginas
            // 
            this.numeropaginas.HeaderText = "Numero Paginas";
            this.numeropaginas.Name = "numeropaginas";
            // 
            // fechaedicion
            // 
            this.fechaedicion.HeaderText = "Fecha Edicion";
            this.fechaedicion.Name = "fechaedicion";
            // 
            // obratitulo
            // 
            this.obratitulo.HeaderText = "titulo de la obra";
            this.obratitulo.Name = "obratitulo";
            this.obratitulo.ReadOnly = true;
            // 
            // portada
            // 
            this.portada.HeaderText = "Portada";
            this.portada.Name = "portada";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(634, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Buscar por ISBN";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtISBN
            // 
            this.txtISBN.Location = new System.Drawing.Point(227, 25);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(100, 20);
            this.txtISBN.TabIndex = 9;
            this.txtISBN.TextChanged += new System.EventHandler(this.txtAutor_TextChanged);
            // 
            // btnAgregarTodos
            // 
            this.btnAgregarTodos.Location = new System.Drawing.Point(634, 334);
            this.btnAgregarTodos.Name = "btnAgregarTodos";
            this.btnAgregarTodos.Size = new System.Drawing.Size(111, 23);
            this.btnAgregarTodos.TabIndex = 16;
            this.btnAgregarTodos.Text = "Agregar todos";
            this.btnAgregarTodos.UseVisualStyleBackColor = true;
            this.btnAgregarTodos.Click += new System.EventHandler(this.btnAgregarTodos_Click);
            // 
            // AgregarEdicionRemota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 369);
            this.Controls.Add(this.btnAgregarTodos);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtISBN);
            this.Name = "AgregarEdicionRemota";
            this.Text = "Agregar edicion desde repositorio virtual";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Button btnAgregarTodos;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Añoedicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeropaginas;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaedicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn obratitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn portada;
    }
}