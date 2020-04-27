using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer2Ev2
{
    public partial class Form2 : Form
    {
        int intentos = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int pin = 1234;
            try
            {
                if (Convert.ToInt32(textBox1.Text) != pin)
                {
                    MessageBox.Show("Contraseña Incorrecta");
                    textBox1.Text = "";
                    intentos++;
                    if (intentos == 3)
                    {
                        DialogResult = DialogResult.Cancel;
                        //Environment.Exit(0);
                    }
                }
                else
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Introduzca números");
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
