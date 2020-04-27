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

namespace Ejer3Ev1
{
    public partial class Form1 : Form
    {
        static bool verificar = false;
        static List<string> alm = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        public void funcion()
        {
            bool encontrado = false;

            string ruta = txtDirectorio.Text;
            txtArchivo.Text = "";
            txtSubDirectorio.Text = "";
            try
            {
                Directory.SetCurrentDirectory(ruta);
                verificar = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Introduzca un valor en directorio");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Introduzca un directorio valido");
            }
            if (verificar)
            {
                alm = new List<string>();
                DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                foreach (DirectoryInfo directoryInfo1 in directoryInfo.GetDirectories())
                {
                    txtSubDirectorio.Text += directoryInfo1 + "\n";
                }

                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    if (txtExtensión.Text == "")
                    {
                        txtArchivo.Text += fileInfo + "\n";
                    }
                    else
                    {
                        if (fileInfo.Extension == "." + txtExtensión.Text)
                        {
                            txtArchivo.Text += fileInfo.Name + "\n";
                            encontrado = true;
                        }
                    }
                }
                if (txtExtensión.Text != "")
                {
                    if (!encontrado)
                    {
                        MessageBox.Show("En ese directorio no dispones de ningun archivo con la extension: " + txtExtensión.Text);
                    }
                }

            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            funcion();
        }
    }
}

