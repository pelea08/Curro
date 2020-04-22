using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3Ev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la app", "Ejercicio 3", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                e.Cancel = true;


            }
        }
        public void colores()
        {
            try
            {
                if (Convert.ToInt32(textBox1.Text) > -1 && Convert.ToInt32(textBox1.Text) < 256 && Convert.ToInt32(textBox2.Text) > -1 && Convert.ToInt32(textBox2.Text) < 256 && Convert.ToInt32(textBox3.Text) > -1 && Convert.ToInt32(textBox3.Text) < 256)
                {
                    this.BackColor = Color.FromArgb(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text));
                }
                else
                {
                    MessageBox.Show("Introduzca números entre el 0 y el 255 en las casillas");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduzca números entre el 0 y el 255 en las casillas");
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            colores();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                MessageBox.Show("Introduzca una ruta para cargar una foto");
            }
            else
            {
                try
                {
                    Bitmap fondo = new Bitmap(textBox4.Text);
                    this.BackgroundImage = fondo;
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("Introduzca una ruta correcta");
                }
            }
        }
        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Yellow;
        }

        private void Button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Transparent;
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Blue;
        }

        private void Button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Transparent;
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Transparent;
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Cyan;
        }

        public void coloresEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                colores();
            }
        }
        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            coloresEnter(sender, e);
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            coloresEnter(sender, e);
        }

        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            coloresEnter(sender, e);
        }
    }
}
