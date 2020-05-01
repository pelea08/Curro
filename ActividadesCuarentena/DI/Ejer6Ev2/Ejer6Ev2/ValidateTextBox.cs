using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Ejer6Ev2
{
    public partial class ValidateTextBox : UserControl
    {

        public ValidateTextBox()
        {
            InitializeComponent();
            textBox1.Location = new Point(10, 10);
            this.Height = textBox1.Height + 20;
            //textBox1.Height = this.Height + 20;
            textBox1.Width = this.Width - 20;
        }

        public enum eTipo
        {
            Numerico,
            Textual
        }


        private bool multiline = false;
        [Category("Nuevo Componentes")]
        [Description("Definimos la propiedad multiline")]
        public bool Multiline
        {
            set
            {
                textBox1.Multiline = multiline;

            }
            get
            {
                return textBox1.Multiline;
            }
        }




        private eTipo tipo;
        [Category("Nuevo Componente")]
        [Description("Define el tipo")]
        public eTipo Tipo
        {
            set
            {
                if (Enum.IsDefined(typeof(eTipo), value))
                {
                    tipo = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }
            }
            get
            {
                return tipo;
            }

        }

        public bool comprobar()
        {
            //OJO PROPIEDADES PUBLIC S Y PRIVADA
            int n = 0;
            string texto = textBox1.Text;
            char[] a = texto.ToCharArray();

            //A la inversa IMPORTANTE
            if (Tipo == eTipo.Numerico)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (Char.IsLetter(a[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (Char.IsDigit(a[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (comprobar())
            {
                Graphics graphics = e.Graphics;
                Brush b = new SolidBrush(Color.Green);
                graphics.DrawRectangle(new Pen(b), 5, 5, this.Width - 10, this.Height - 10);
            }
            else
            {
                Graphics graphics = e.Graphics;
                Brush b = new SolidBrush(Color.Red);
                graphics.DrawRectangle(new Pen(b), 5, 5, this.Width - 10, this.Height - 10);
            }

        }

        private string texto;
        [Category("Nuevo Componente")]
        [Description("Asignamos un texto determinado")]
        public string Texto
        {
            set
            {
                textBox1.Text = value;
            }
            get
            {

                return textBox1.Text;
            }
        }

        private void ValidateTextBox_Load(object sender, EventArgs e)
        {

        }

        [Category("Nuevo Componente")]
        [Description("Definimos la modificacion del texto para activar el colorido")]
        public event System.EventHandler CambiaTexto;
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            CambiaTexto?.Invoke(sender, e);
            this.Refresh();
        }
    }
}
