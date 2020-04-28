using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer3Ev2
{
    [
        DefaultProperty("TextLbl"),
        DefaultEvent("Load")
        ]
    public partial class LabelTextBox : UserControl
    {

        private void recolorcar()
        {
            switch (posicion)
            {
                case ePosicion.DERECHA:
                    txt.Location = new Point(0, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    lbl.Location = new Point(txt.Width + Separacion, 0);
                    this.Height = Math.Max(txt.Height, lbl.Height);

                    break;
                case ePosicion.IZQUIERDA:
                    lbl.Location = new Point(0, 0);
                    txt.Location = new Point(lbl.Width + Separacion, 0);
                    txt.Width = this.Width - lbl.Width - Separacion;
                    this.Height = Math.Max(txt.Height, lbl.Height);
                    break;

            }

        }
        public LabelTextBox()
        {
            InitializeComponent();
            TextLbl = Name;
            TextTxt = "";
            recolocar();

        }

        private void LabelTextBox_Load(object sender, EventArgs e)
        {

        }


        public enum ePosicion
        {
            IZQUIERDA, DERECHA
        }

        private ePosicion posicion = ePosicion.IZQUIERDA;

        [Category("Nuevo Componente")]
        [Description("Indica si label sitúa a la izquierda o derecha del textbox")]
        public ePosicion Posicion
        {
            set
            {
                if (Enum.IsDefined(typeof(ePosicion), value))
                {
                    posicion = value;
                    recolocar();
                    CambiaPoscion?.Invoke(this, new EventArgs());
                }
                else
                {
                    throw new InvalidEnumArgumentException();
                }

            }
            get
            {
                return posicion;
            }

        }
        void recolocar() { }
        private int separacion = 0;
        public int Separacion
        {
            set
            {
                if (value >= 0)
                {
                    separacion = value;
                    recolocar();
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            get
            {
                return separacion;
            }
        }
        [Category("Nuevo Componente")]
        [Description("Texto asociado a la label")]
        public string TextLbl
        {
            set
            {
                lbl.Text = value;
                recolocar();
            }
            get
            {
                return lbl.Text;
            }
        }
        [Category("Nuevo Componente")]
        [Description("Texto asociado al textbox")]
        public string TextTxt
        {
            set
            {
                txt.Text = value;
            }
            get
            {
                return txt.Text;
            }
        }

        private void LabelTextBox_SizeChanged(object sender, EventArgs e)
        {
            recolocar();
        }

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
        [Category("Nuevo Componente")]
        [Description(" Se lanza cuando la propiedad Posición cambia")]
        public event System.EventHandler CambiaPoscion;

        private void Txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
