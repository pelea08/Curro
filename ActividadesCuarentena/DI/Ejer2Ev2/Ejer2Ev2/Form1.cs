﻿using System;
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
                int y = 85;
                int x = 40;
                for (int i = 0; i < 12; i++)
                {

                    btn = new Button();
                    btn.Location = new Point(x, y);
                    btn.Name = "boton" + i;
                    btn.Size = new System.Drawing.Size(40, 30);
                    btn.Text = (i + 1) + "";
                    btn.UseVisualStyleBackColor = true;


                    Controls.Add(btn);
                    btn.MouseEnter += new System.EventHandler(this.Form1_MouseEnter);
                    btn.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
                    btn.Click += new System.EventHandler(dibujarNumeros);
                    btn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button1_MouseDown);


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
        void dibujarNumeros(object sender, EventArgs e)
        {
            string numero = ((Button)sender).Text;
            textBox1.Text += numero;
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            foreach (Control item in this.Controls)
            {
                if (item is Button)
                {
                    ((Button)item).BackColor = Color.Transparent;
                }
            }

        }

        private void GrabarNúmeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Solo archivos txt (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, false))
                {
                    sw.WriteLine(textBox1.Text);
                }
            }
        }
        void cambiarColor(object sender, EventArgs e, Color color)
        {
            if (sender is Button)
            {
                if (((Button)sender).BackColor != Color.DarkSalmon)
                {
                    ((Button)sender).BackColor = color;

                }
            }

        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            cambiarColor(sender, e, Color.Yellow);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            cambiarColor(sender, e, Color.Transparent);
        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            ((Button)sender).BackColor = Color.DarkSalmon;
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa realizado por: Donald Knuth");
        }

        private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

