using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LabelTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Text = "Letra:  " + e.KeyChar;
        }

        private void LabelTextBox1_CambiaPoscion(object sender, EventArgs e)
        {
            MessageBox.Show("EIIIIIIIIII");
        }

        private void CustomControl11_Click(object sender, EventArgs e)
        {

        }
    }
}
