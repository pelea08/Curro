using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejer1Ev2
{
    public partial class Form1 : Form
    {
        Form2 f = new Form2();
        static bool bandePuerto = false;
        public Form1()
        {
            InitializeComponent();
        }
        public void funcionConectar(string texto)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse(f.ip), f.puerto);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                s.Connect(ie);
                bandePuerto = true;
            }
            catch (SocketException)
            {
                f.puerto++;
                bandePuerto = false;
            }
            try
            {
                using (NetworkStream ns = new NetworkStream(s))
                using (StreamWriter sw = new StreamWriter(ns))
                using (StreamReader sr = new StreamReader(ns))
                {

                    sw.WriteLine(texto);
                    sw.Flush();

                    label1.Text = sr.ReadLine();
                }

            }
            catch (IOException)
            {
                label1.Text = "Excepcion";
            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            funcionConectar("HORA");

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            funcionConectar("FECHA");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            funcionConectar("TODO");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            funcionConectar("APAGAR");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            f.ShowDialog();
        }
    }
}
