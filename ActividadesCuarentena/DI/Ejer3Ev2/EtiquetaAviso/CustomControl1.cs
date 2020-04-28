using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtiquetaAviso
{

    public partial class CustomControl1 : Control
    {
        public CustomControl1()
        {
            InitializeComponent();
        }
        public enum eMarca
        {
            Nada,
            Cruz,
            Circulo,
            Imagen
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            int grosor = 0;
            int offsetX = 0;
            int offsetY = 0;

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;


            //OJO PONER ESTO AL PRINCIPIO SI NO ME LO SOLAPA
            LinearGradientBrush brush = new LinearGradientBrush(new Point(1, 0), new Point(50, 100), ColorInicio, ColorFinal);

            if (Gradiente)
            {
                g.FillRectangle(brush, 0, 0, this.Width, this.Height);

            }
            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 20;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor,
                   this.Font.Height, this.Font.Height);
                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor;
                    break;
                case eMarca.Cruz:
                    grosor = 20;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, this.Font.Height,
                   this.Font.Height);
                    g.DrawLine(lapiz, this.Font.Height, grosor, grosor,
                   this.Font.Height);
                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor / 2;
                    //Liberar Memoria
                    lapiz.Dispose();
                    break;
                case eMarca.Imagen:
                    //Claro es la variable que recoge la ruta
                    //ACUERDATE COMPROBAR NULOS SI NO PETA TODO 
                    if (imagenMarca != null)
                    {
                        g.DrawImage(imagenMarca, grosor, grosor, this.Font.Height, this.Font.Height);
                    }
                    else
                    {
                        marca = eMarca.Nada;
                    }

                    offsetX = this.Font.Height + grosor;
                    offsetY = grosor / 2;
                    break;
            }
            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX + grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);

            b.Dispose();

        }


        private eMarca marca = eMarca.Circulo;
        public eMarca Marca
        {

            set
            {
                marca = value;
                this.Refresh();
            }
            get
            {
                return marca;
            }

        }

        private Image imagenmarca = new Bitmap("C:/Users/User/Documents/GitHub/Curro/ActividadesCuarentena/DI/Ejer3Ev2/a45.jpg");
        [Category("Nuevo Componente")]
        [Description("Inicializamos la Imagen")]
        public Image imagenMarca
        {
            set
            {
                imagenmarca = value;
                this.Refresh();
            }
            get
            {
                return imagenmarca;
            }
        }




        private Boolean gradiente = false;
        [Category("Nuevo Componente")]
        [Description("Activa o desactiva el gradiente")]
        public Boolean Gradiente
        {
            set
            {
                gradiente = value;
                this.Refresh();
            }
            get
            {
                return gradiente;
            }

        }
        private Color colorinicio = Color.Aqua;
        [Category("Nuevo Componente")]
        [Description("Establece color inicial")]
        public Color ColorInicio
        {
            set
            {
                colorinicio = value;
                this.Refresh();
            }
            get
            {
                return colorinicio;
            }
        }
        private Color colorfinal = Color.Red;
        [Category("Nuevo Componente")]
        [Description("Establecer color final")]
        public Color ColorFinal
        {
            set
            {
                colorfinal = value;
                this.Refresh();
            }
            get
            {
                return colorfinal;
            }
        }



    }
}
