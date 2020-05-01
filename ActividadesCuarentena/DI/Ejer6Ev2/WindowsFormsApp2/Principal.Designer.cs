namespace WindowsFormsApp2
{
    partial class Principal
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
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.borrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(404, 104);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(120, 84);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(363, 203);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(544, 203);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(75, 23);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(31, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 122);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(668, 88);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(120, 84);
            this.listBox2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(665, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Parejas Validas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox7);
            this.panel1.Controls.Add(this.pictureBox6);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(125, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 174);
            this.panel1.TabIndex = 7;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Location = new System.Drawing.Point(430, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(80, 80);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox7.TabIndex = 13;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Location = new System.Drawing.Point(344, 0);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(80, 80);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox6.TabIndex = 12;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Location = new System.Drawing.Point(258, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(80, 80);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Location = new System.Drawing.Point(172, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(80, 80);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox4.TabIndex = 10;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(86, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(80, 80);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem1,
            this.acercaDeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.borrarToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(75, 24);
            this.clientesToolStripMenuItem1.Text = "&Clientes";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(135, 26);
            this.nuevoToolStripMenuItem1.Text = "&Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // borrarToolStripMenuItem
            // 
            this.borrarToolStripMenuItem.Name = "borrarToolStripMenuItem";
            this.borrarToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.borrarToolStripMenuItem.Text = "&Borrar";
            this.borrarToolStripMenuItem.Click += new System.EventHandler(this.Button2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.salirToolStripMenuItem.Text = "&Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.SalirToolStripMenuItem_Click);
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(89, 24);
            this.acercaDeToolStripMenuItem.Text = "&Acerca de";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.AcercaDeToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(401, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nombres Clientes";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.listBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.Load += new System.EventHandler(this.Principal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem borrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label3;
    }
}

