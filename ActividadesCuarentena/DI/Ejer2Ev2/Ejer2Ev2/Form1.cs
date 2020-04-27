using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer2Ev2
{
    public partial class Form1 : Form
    {
        Form2 f = new Form2();
        Button btn;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (f.ShowDialog() == DialogResult.OK)
            {
                //Generar Botones LOCATION=40,77  size:176,22
                int y = 85;
                int x = 40;
                for (int i = 0; i < 12; i++)
                {

                    btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Name = "boton" + i;
                    btn.Size = new System.Drawing.Size(40, 30);
                    btn.TabIndex = 0;
                    btn.Text = (i + 1) + "";
                    btn.UseVisualStyleBackColor = true;
                    Controls.Add(btn);
                    x += 42;
                    int div = i + 1;
                    if (div % 3 == 0)
                    {
                        y += 35;
                        x = 40;
                    }
                    if (i == 9)
                    {
                        btn.Text = "*";
                    }
                    if (i == 10)
                    {
                        btn.Text = "0";
                    }
                    if (i == 11)
                    {
                        btn.Text = "#";
                    }
                }
            }
            else /*if (f.ShowDialog() == DialogResult.Cancel)*/
            {
                this.Close();

            }



        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void GrabarNúmeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Solo archivos txt (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {

                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,true)) {
                    sw.WriteLine(textBox1.Text);
                }
            }
        }
    }
}
