using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string[] titulo = { "E", "J", "E", "R", "C", "I", "C", "I", "O", " ", "1" };
            contador++;
            if (contador % 2 == 0)
            {
                if (i == titulo.Length)
                {
                    i = 0;
                    this.Text = "";
                }
                this.Text += titulo[i];
                i++;
            }
            if (contador % 4 == 0)
            {
                if (!bandera)
                {
                    this.Icon = new Icon("C:/Users/User/Downloads/a.ico");
                    bandera = true;
                }
                else
                {
                    this.Icon = new Icon("C:/Users/User/Downloads/b.ico");
                    bandera = false;
                }
            }
        }
        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void ListBox2_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox2, "Elementos Restantes:" + listBox2.Items.Count);
        }

        private void ListBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(listBox1, "Esto es el listbox 1");
        }

        private void Button1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Añade elementos a la lista");
        }

        private void Button2_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button2, "Quita elementos a la lista");
        }

        private void Button3_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button3, "Pasa de la lista 1 a la lista 2");
        }

        private void Button4_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button4, "Pasa de la lista 2 a la lista 1");
        }

        private void TextBox1_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(textBox1, "Son las palabras que inserta la listbox1");
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

                try
                {
                    string variable = listBox2.SelectedItem.ToString();
                    listBox2.Items.Remove(variable);
                    listBox1.Items.Add(variable);
                    lblElementos.Text = "Numero de elementos: " + listBox1.Items.Count;
                }
                catch (NullReferenceException)
                {
                }

            }

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblIndice.Text = "Elemento Selecionado: " + listBox1.SelectedIndex;

        }
    }
}
