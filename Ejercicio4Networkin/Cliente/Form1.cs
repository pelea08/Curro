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
        IPAddress ipp;
        static readonly object l = new object();

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

            button2.Enabled = true;
            txtAdivinar.Enabled = true;
            button1.Enabled = false;
        }
        private void conectar(string texto)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Loopback, 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(ie);
            ipp = ie.Address;
            using (NetworkStream ns = new NetworkStream(s))
            using (StreamReader sr = new StreamReader(ns))
            using (StreamWriter sw = new StreamWriter(ns))
            {
                //OJO WHILE
                sw.WriteLine(texto);
                sw.Flush();
                palabraReseolver = sr.ReadLine();
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
            else if (cont == 4)
            {
                g.DrawLine(new Pen(Color.Red), 100, 150, 100, 100);
                g.DrawLine(new Pen(Color.Red), 100, 100, 150, 100);
                g.DrawLine(new Pen(Color.Red), 150, 100, 150, 115);
                g.DrawEllipse(new Pen(Color.Blue), 142, 115, 15, 15);
                timer1.Stop();
                grabarRecord(segundos, "peter", ipp);
                //Introducir nombre
                //MessageBox.Show("Introduzca su nombre", "TITULO", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }

        }

        private void grabarRecord(int tiempo, String nombre, IPAddress iPAddress)
        {
            //Tuve que informarme y usar lo de FileStream si no me petaba
            FileStream f = new FileStream("C:/Users/User/Desktop/getrecords.txt", FileMode.Open);
            using (StreamReader sr = new StreamReader(f))
            using (StreamWriter sw = new StreamWriter(f))

            {
                String[] palabras = sr.ReadLine().Split(' ');
                List<int> almacen = new List<int>();
                for (int i = 0; i < palabras.Length; i++)
                {
                    //Añadimos solo numero de primera fila
                    almacen.Add(Convert.ToInt32(palabras[i]));
                    i = i + 2;
                    if (i > palabras.Length)
                    {
                        break;
                    }
                }
                if (almacen.Count < 10)
                {
                    //{
                    sw.WriteLine(tiempo + " " + nombre + " " + iPAddress);
                    sw.Flush();
                    //}
                }
                else
                {
                    for (int i = 0; i < almacen.Count; i++)
                    {
                        if (almacen[i] > segundos)
                        {

                            sw.WriteLine(tiempo + "" + nombre + "" + iPAddress);
                            sw.Flush();
                            break;
                        }
                    }
                }
            }
            //Nombre 3 caracteres
            //Maximo 10 recors


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

        private void Button4_Click(object sender, EventArgs e)
        {
            conectar("getrecords");
            txtRecords.Text = "" + palabraReseolver;
        }
    }
}
