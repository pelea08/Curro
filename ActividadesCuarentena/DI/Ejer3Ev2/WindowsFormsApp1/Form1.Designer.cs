namespace WindowsFormsApp1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.customControl11 = new EtiquetaAviso.CustomControl1();
            this.SuspendLayout();
            // 
            // customControl11
            // 
            this.customControl11.ColorFinal = System.Drawing.Color.Red;
            this.customControl11.ColorInicio = System.Drawing.Color.Aqua;
            this.customControl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customControl11.Gradiente = true;
            this.customControl11.imagenMarca = ((System.Drawing.Image)(resources.GetObject("customControl11.imagenMarca")));
            this.customControl11.Location = new System.Drawing.Point(127, 127);
            this.customControl11.Marca = EtiquetaAviso.CustomControl1.eMarca.Imagen;
            this.customControl11.Name = "customControl11";
            this.customControl11.Size = new System.Drawing.Size(617, 83);
            this.customControl11.TabIndex = 0;
            this.customControl11.Text = "customControl11";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.customControl11);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private EtiquetaAviso.CustomControl1 customControl11;
    }
}

