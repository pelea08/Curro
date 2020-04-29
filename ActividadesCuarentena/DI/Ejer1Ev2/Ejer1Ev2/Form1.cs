using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ejer1Ev2
{

    public partial class Form1 : Form
    {
        int contador = 0;
        int i = 0;
        bool bandera = false;
        public Form1()
        {
            InitializeComponent();
            lblElementos.Text = "Numero de elementos: " + listBox1.Items.Count;
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            string titulo1 = "Ejercicio 1";
            contador++;
            if (contador % 2 == 0)
            {
                if (i == titulo1.Length)
                {
                    i = 0;
                    this.Text = "";
                }
                this.Text += titulo1[i];
                i++;
            }
            if (contador % 4 == 0)
            {
                if (!bandera)
                {
                    this.Icon = new Icon("a.ico");
                    bandera = true;
                }
                else
                {
                    this.Icon = new Icon("b.ico");
                    bandera = false;
                }
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Add(textBox1.Text);
                textBox1.Text = "";
            }
            lblElementos.Text = "Numero de elementos: " + listBox1.Items.Count;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                }
                lblElementos.Text = "Numero de elementos: " + listBox1.Items.Count;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count != 0)
            {
                for (int i = listBox1.Items.Count - 1; i >= 0; i--)
                {
                    if (listBox1.SelectedIndices.Contains(i))
                    {
                        listBox2.Items.Insert(0, listBox1.Items[i]);
                        listBox1.Items.RemoveAt(i);
                    }
                }
                lblElementos.Text = "Numero de elementos: " + listBox1.Items.Count;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count != 0)
            {
                if (listBox2.SelectedItem != null)
                {
                    string variable = listBox2.SelectedItem.ToString();
                    listBox2.Items.Remove(variable);
                    listBox1.Items.Add(variable);
                    lblElementos.Text = "Numero de elementos: " + listBox1.Items.Count;
                }
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIndice.Text = "Elemento Selecionado: " + listBox1.SelectedIndex;

        }

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox2, "Elementos Restantes:" + listBox2.Items.Count);

        }

    }

}
