#define TECLAS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer4Ev1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void cordenadas(object sender, MouseEventArgs e)
        {

            if (sender is Button)
            {
                int cordenadaX = ((Button)sender).Location.X;
                int cordenadaY = ((Button)sender).Location.Y;

                this.Text = "Mouse Tester X:" + (cordenadaX + e.X) + " Y: " + (cordenadaY + e.Y);
            }
            else
            {
                this.Text = "Mouse Tester X:" + e.X + " Y: " + e.Y;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            cordenadas(sender, e);
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Text = "Mouse Tester";
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Transparent;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Transparent;
            }
            else
            {
                button2.BackColor = Color.Transparent;
                button1.BackColor = Color.Transparent;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                button1.BackColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Right)
            {
                button2.BackColor = Color.Blue;
            }
            else
            {
                button2.BackColor = Color.Blue;
                button1.BackColor = Color.Red;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Desea salir?", "Mouse Tester", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
#if TECLA
        //Hago lo de poner keypress vacio para que al ejecutar no me dea problemas 
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        { }
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Text = "Mouse Tester";
            }
            else
            {
                this.Text = e.KeyCode.ToString();
            }
        }
#else
        //AQUI ABAJO IGUAL QUE ARRIBA PARA EVITAR ERRORES Y TENER QUE ANDAR A AÑADIRLO
        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        { }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Text = "Mouse Tester";
            }
            else
            {
                this.Text = e.KeyChar.ToString();
            }
        }
#endif
    }
}
