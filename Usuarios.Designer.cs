﻿
namespace Inicio_Bliblioteca
{
    partial class Usuarios
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lNombre = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lFechaRegistro = new System.Windows.Forms.Label();
            this.lPuntaje = new System.Windows.Forms.Label();
            this.lMail = new System.Windows.Forms.Label();
            this.lUltimoInicio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEditarUsuario = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(23, 51);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(215, 70);
            this.btnRegistrar.TabIndex = 1;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(23, 159);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(215, 70);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(23, 269);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(215, 70);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lNombre
            // 
            this.lNombre.AutoSize = true;
            this.lNombre.Location = new System.Drawing.Point(470, 30);
            this.lNombre.Name = "lNombre";
            this.lNombre.Size = new System.Drawing.Size(35, 13);
            this.lNombre.TabIndex = 4;
            this.lNombre.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lFechaRegistro);
            this.panel1.Controls.Add(this.lPuntaje);
            this.panel1.Controls.Add(this.lMail);
            this.panel1.Controls.Add(this.lUltimoInicio);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(376, 51);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 285);
            this.panel1.TabIndex = 6;
            // 
            // lFechaRegistro
            // 
            this.lFechaRegistro.AutoSize = true;
            this.lFechaRegistro.Location = new System.Drawing.Point(123, 230);
            this.lFechaRegistro.Name = "lFechaRegistro";
            this.lFechaRegistro.Size = new System.Drawing.Size(35, 13);
            this.lFechaRegistro.TabIndex = 7;
            this.lFechaRegistro.Text = "label1";
            // 
            // lPuntaje
            // 
            this.lPuntaje.AutoSize = true;
            this.lPuntaje.Location = new System.Drawing.Point(123, 162);
            this.lPuntaje.Name = "lPuntaje";
            this.lPuntaje.Size = new System.Drawing.Size(35, 13);
            this.lPuntaje.TabIndex = 6;
            this.lPuntaje.Text = "label1";
            // 
            // lMail
            // 
            this.lMail.AutoSize = true;
            this.lMail.Location = new System.Drawing.Point(123, 95);
            this.lMail.Name = "lMail";
            this.lMail.Size = new System.Drawing.Size(35, 13);
            this.lMail.TabIndex = 5;
            this.lMail.Text = "label1";
            // 
            // lUltimoInicio
            // 
            this.lUltimoInicio.AutoSize = true;
            this.lUltimoInicio.Location = new System.Drawing.Point(123, 26);
            this.lUltimoInicio.Name = "lUltimoInicio";
            this.lUltimoInicio.Size = new System.Drawing.Size(35, 13);
            this.lUltimoInicio.TabIndex = 4;
            this.lUltimoInicio.Text = "label1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fecha de Registro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Puntaje:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Mail:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ultimo inicio:";
            // 
            // btnEditarUsuario
            // 
            this.btnEditarUsuario.Location = new System.Drawing.Point(482, 352);
            this.btnEditarUsuario.Name = "btnEditarUsuario";
            this.btnEditarUsuario.Size = new System.Drawing.Size(111, 25);
            this.btnEditarUsuario.TabIndex = 7;
            this.btnEditarUsuario.Text = "Editar Usuario";
            this.btnEditarUsuario.UseVisualStyleBackColor = true;
            this.btnEditarUsuario.Click += new System.EventHandler(this.btnEditarUsuario_Click);
            // 
            // Usuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnEditarUsuario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lNombre);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnRegistrar);
            this.Name = "Usuarios";
            this.Size = new System.Drawing.Size(623, 395);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lNombre;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditarUsuario;
        private System.Windows.Forms.Label lFechaRegistro;
        private System.Windows.Forms.Label lPuntaje;
        private System.Windows.Forms.Label lMail;
        private System.Windows.Forms.Label lUltimoInicio;
    }
}
