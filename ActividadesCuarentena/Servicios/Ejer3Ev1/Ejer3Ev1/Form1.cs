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

namespace Ejer3Ev1
{
    public partial class Form1 : Form
    {
        static bool verificar = false;
        public Form1()
        {
            InitializeComponent();
        }

        public void funcion()
        {
            List<string> alm = new List<string>();

            string ruta = txtDirectorio.Text;
            txtArchivo.Text = "";
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
                DirectoryInfo directoryInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
                foreach (DirectoryInfo directoryInfo1 in directoryInfo.GetDirectories())
                {
                    txtSubDirectorio.Text += directoryInfo1 + "\n";
                }
                foreach (FileInfo fileInfo in directoryInfo.GetFiles())
                {
                    //Si no pone nada mostramos todo tipo de archivos
                    if (txtExtensión.Text == "")
                    {
                        txtArchivo.Text += fileInfo + "\n";
                    }
                    else
                    {
                        alm.Add(fileInfo.Name);
                        for (int i = 0; i < alm.Count; i++)
                        {
                            if (alm[i].Split('.')[1] == txtExtensión.Text)
                            {
                                txtArchivo.Text += fileInfo + "\n";
                            }
                        }
                    }
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            funcion();
        }
        private void TxtDirectorio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                funcion();
            }
        }
    }
}

