using System;
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
    public enum eAficion
    {
        Manga,
        sciFi,
        RPG,
        Fantasia,
        Terror,
        Tecnologia
    }
    public enum eSexo
    {
        Hombre,
        Mujer

    }
    public struct sFriki
    {
        public string Nombre;
        public int Edad;
        public eAficion aficionPrincipal;
        public eSexo Sexo;
        public eSexo sexoOpuesto;
        public string Foto;

    }

    public partial class Principal : Form
    {
        IntroducionDatos f = new IntroducionDatos();
         List<sFriki> almacenFriki = new List<sFriki>();

        public Principal()
        {
            InitializeComponent();
        }
        



        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (f.ShowDialog() == DialogResult.OK) {

            }
        }
    }
}
