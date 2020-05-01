﻿using Ejer6Ev2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public struct sFriki
    {
        public string Nombre;
        public int Edad;
        public eAficion aficionPrincipal;
        public eSexo Sexo;
        public eSexo sexoOpuesto;
        public string Foto;

        public enum eSexo
        {
            Hombre,
            Mujer

        }
        public enum eAficion
        {
            Manga = 1,
            sciFi,
            RPG,
            Fantasia,
            Terror,
            Tecnologia
        }

        public sFriki(string nombre, int edad, eAficion aficionPrincipal, eSexo sexo, eSexo sexoOpuesto, string foto)
        {
            Nombre = nombre;
            Edad = edad;
            this.aficionPrincipal = aficionPrincipal;
            Sexo = sexo;
            this.sexoOpuesto = sexoOpuesto;
            Foto = foto;
        }
    }

    public partial class Principal : Form
    {
        public List<sFriki> frikis = new List<sFriki>();
        sFriki friki;
        DialogResult res;
        int cont = 0;
        int i = 0;
        public Principal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1) {
                if (MessageBox.Show("Esta seguro que desea borrar", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    int i = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(i);
                    frikis.RemoveAt(i);
                }

            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //public void actualizarNombres()
        //{
        //    foreach (sFriki x in frikis)
        //    {
        //        listBox1.Items.Add(x.Nombre);
        //    }
        //}
        private void Principal_Load(object sender, EventArgs e)
        {
            ///NOMBRES DE LOS CLIENTES
            /////NO TIENE SENTID NO VA
            //actualizarNombres();

        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Programa: Apple 1 Autor: Steve Wozniak");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            cont++;
            string tit = "Ejercicio 6";
            if (cont % 1 == 0)
            {
                if (i == tit.Length)
                {
                    i = 0;
                    this.Text = "";
                }
                this.Text += tit[i];
                i++;

            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            IntroducionDatos fa = new IntroducionDatos();

            if (fa.ShowDialog() == DialogResult.OK)
            {
                //actualizarNombres();
                frikis.Add(fa.sFriki);
                listBox1.Items.Add(fa.sFriki.Nombre);


            }
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}