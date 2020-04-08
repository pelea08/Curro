using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class Form3 : Form
    {
        public String nombre;
        public bool bandera = false;
        public Form3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text.Length==3)
            {
                //button1.DialogResult = DialogResult.OK;
                nombre = textBox1.Text;
                bandera = true;
            }
            else
            {
                bandera = false;
                MessageBox.Show("Introduzca un tamaño y nombre valido");
            }
        }
    }
}
