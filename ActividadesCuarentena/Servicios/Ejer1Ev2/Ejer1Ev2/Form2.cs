using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer1Ev2
{
    public partial class Form2 : Form
    {
        //VALORES POR DEFECTO
        public int puerto = 31416;
        public string ip = "127.0.0.1";
        public Form2()
        {
            InitializeComponent();
        }
        public bool verificarIP(string dirIp)
        {
            string[] troceo = dirIp.Split('.');
            if (troceo.Length != 4)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < troceo.Length; i++)
                {
                    if (Convert.ToInt32(troceo[i]) < 0 || Convert.ToInt32(troceo[i]) > 255)
                    {
                        return false;
                    }
                }
            }
            return true;

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (txtPuerto.Text != "" && txtIP.Text != "")
            {
                if (Convert.ToInt32(txtPuerto.Text) > 0 && Convert.ToInt32(txtPuerto.Text) < 65536)
                {
                    puerto = Convert.ToInt32(txtPuerto.Text);
                    if (verificarIP(txtIP.Text))
                    {
                        ip = txtIP.Text;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Introduzca una ip valida");
                    }
                }
                else
                {
                    MessageBox.Show("Introduzca un puerto adecuado");
                }


            }
        }
    }
}
