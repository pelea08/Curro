﻿namespace WindowsFormsApp1
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.validateTextBox1 = new Ejer6Ev2.ValidateTextBox();
            this.SuspendLayout();
            // 
            // validateTextBox1
            // 
            this.validateTextBox1.Location = new System.Drawing.Point(292, 110);
            this.validateTextBox1.Multiline = false;
            this.validateTextBox1.Name = "validateTextBox1";
            this.validateTextBox1.Size = new System.Drawing.Size(150, 41);
            this.validateTextBox1.TabIndex = 0;
            this.validateTextBox1.Texto = "";
            this.validateTextBox1.Tipo = Ejer6Ev2.ValidateTextBox.eTipo.Numerico;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.validateTextBox1);
            this.Name = "Form1";
            this.Text = "Form12";
            this.ResumeLayout(false);

        }

        #endregion

        private Ejer6Ev2.ValidateTextBox validateTextBox1;
    }
}

