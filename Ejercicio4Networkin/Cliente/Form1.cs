using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Cliente
{
    public partial class Form1 : Form
    {
        String palabraReseolver;
        String labelAuxiliar;
        bool bandera = false;
        String palabraNueva;
        String[] rayitas;
        int cont;
        bool banderaVerificar = false;
        static bool banderaPuntos = false;
        int segundos = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String texto = "getword";
            conectar(texto);
            button2.Enabled = true;
            txtAdivinar.Enabled = true;
            button1.Enabled = false;
        }
        private void conectar(string texto)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Loopback, 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ie);
            using (NetworkStream ns = new NetworkStream(s))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {


                //while (true) {

                sw.WriteLine(texto);
                sw.Flush();
                palabraReseolver = sr.ReadLine();
                int tamañoPalabra = palabraReseolver.Length;
                String separaciones = "__-";
                String separacionesFinal = "__";
                label1.Text = "";
                for (int i = 0; i < tamañoPalabra; i++)
                {
                    if (tamañoPalabra - 1 == i)
                    {
                        label1.Text += separacionesFinal;
                    }
                    else
                    {
                        label1.Text += separaciones;

                    }

                }
                labelAuxiliar = label1.Text;



                //}




            }

        }
        //DIFRENCIAR MAYUSCULAS MINISCULAS cualquier palabra que meta en el textbox la pasamos a minuscula
        private void Button2_Click(object sender, EventArgs e)
        {
            //se vacia cada click que doy
            List<int> almacenPosiciones = new List<int>();

            if (!bandera)
            {
                rayitas = labelAuxiliar.Split('-');
                bandera = true;
                label1.Text = "";

            }
            else
            {
                //rayitas = palabraNueva.Split('-');
                //label1.Text = "";

            }
            String letraTextbox = txtAdivinar.Text;


            char[] caracter = palabraReseolver.ToCharArray();
            for (int i = 0; i < caracter.Length; i++)
            {
                if (caracter[i].ToString().Equals(letraTextbox))
                {
                    almacenPosiciones.Add(i);
                    banderaPuntos = true;
                }

            }
            if (!banderaPuntos)
            {
                cont++;
                banderaVerificar = true;
                for (int k = 0; k < rayitas.Length; k++)
                {
                    if (rayitas.Length - 1 == k)
                    {
                        palabraNueva += rayitas[k];
                    }
                    else
                    {
                        palabraNueva += rayitas[k] + "-";
                    }
                }
                label1.Text = palabraNueva;
                palabraNueva = "";
            }
            else
            {


                for (int j = 0; j < almacenPosiciones.Count; j++)
                {
                    rayitas[almacenPosiciones[j]] = letraTextbox;
                    lblVdas.Text = "GG";
                    label1.Text = "";
                    for (int k = 0; k < rayitas.Length; k++)
                    {
                        if (rayitas.Length - 1 == k)
                        {
                            palabraNueva += rayitas[k];
                        }
                        else
                        {
                            palabraNueva += rayitas[k] + "-";
                        }
                    }
                    label1.Text = palabraNueva;
                    palabraNueva = "";

                }
            }


            this.Refresh();




        }
        protected override void OnPaint(PaintEventArgs e)
        {
            //if (banderaVerificar)
            //{


            Graphics g = e.Graphics;

            if (cont == 1)
            {
                g.DrawLine(new Pen(Color.Red), 100, 150, 100, 100);
                

            }
            else if (cont == 2)
            {
                g.DrawLine(new Pen(Color.Red), 100, 150, 100, 100);
                g.DrawLine(new Pen(Color.Red), 100, 100, 150, 100);

            }
            else if (cont == 3)
            {
                g.DrawLine(new Pen(Color.Red), 100, 150, 100, 100);
                g.DrawLine(new Pen(Color.Red), 100, 100, 150, 100);
                g.DrawLine(new Pen(Color.Red), 150, 100, 150, 115);
            }
            else if (cont >= 4)
            {
                g.DrawLine(new Pen(Color.Red), 100, 150, 100, 100);
                g.DrawLine(new Pen(Color.Red), 100, 100, 150, 100);
                g.DrawLine(new Pen(Color.Red), 150, 100, 150, 115);
                g.DrawEllipse(new Pen(Color.Blue), 142, 115, 15, 15);
                timer1.Stop();
            }
            //switch (cont)
            //{

            //    case 1:
            //        g.DrawLine(new Pen(Color.Red), 100, 150, 100, 100);
            //        break;
            //    case 2:
            //        g.DrawLine(new Pen(Color.Red), 150, 100, 150, 115);
            //        break;
            //    case 3:
            //        g.DrawEllipse(new Pen(Color.Blue), 142, 115, 15, 15);
            //        break;
            //}



            //}

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            segundos++;
        }
    }
}
