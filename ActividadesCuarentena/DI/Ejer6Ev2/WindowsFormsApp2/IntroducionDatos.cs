using System;
using WindowsFormsApp2;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer6Ev2
{

    public partial class IntroducionDatos : Form
    {
        public sFriki sFriki;
        Principal f = new Principal();
        public IntroducionDatos()
        {
            InitializeComponent();
        }

        private void IntroducionDatos_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add(Enum.GetValues(typeof(sFriki.eAficion)));
            comboBox1.DataSource = Enum.GetValues(typeof(sFriki.eAficion));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ruta;
            openFileDialog1.Filter = " archivos txt (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ruta = openFileDialog1.FileName;
                txtFoto.Text = ruta;

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Texto != "" & txtFoto.Text != "" & Convert.ToInt32(txtEdad.Texto) != 0 & comboBox1.SelectedValue.ToString() != "")
                {
                    string n1 = "";
                    if (radioButton1.Checked)
                    {
                        n1 = "Hombre";
                    }
                    else if (radioButton2.Checked)
                    {
                        n1 = "Mujer";
                    }


                    string n2 = "";
                    if (radioButton3.Checked)
                    {
                        n2 = "Hombre";
                    }
                    else if (radioButton4.Checked)
                    {
                        n2 = "Mujer";
                    }
                    sFriki = new sFriki(txtNombre.Texto, Convert.ToInt32(txtEdad.Texto), (sFriki.eAficion)Enum.Parse(typeof(sFriki.eAficion), comboBox1.SelectedItem.ToString()), (sFriki.eSexo)Enum.Parse(typeof(sFriki.eSexo), n1.ToString()), (sFriki.eSexo)Enum.Parse(typeof(sFriki.eSexo), n2.ToString()), txtFoto.Text);
                    f.frikis.Add(sFriki);

                    //f.actualizarNombres();
                    DialogResult = DialogResult.OK;

                }
                else
                {
                    MessageBox.Show("Rellene todos los campos");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Rellene todos los campos");

            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
