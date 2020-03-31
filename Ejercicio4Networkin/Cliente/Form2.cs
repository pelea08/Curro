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

namespace Cliente
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog a = new OpenFileDialog())
            {

                if (a.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (StreamWriter añadir = new StreamWriter("C:/Users/User/Desktop/getword.txt", true)) {
                if (textBox1.Text != null && textBox1.Text != "") {

                    añadir.WriteLine(textBox1.Text);
                    añadir.Flush();

                }

            }
        }
    }
}
