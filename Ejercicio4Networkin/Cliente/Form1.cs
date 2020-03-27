﻿using System;
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
        //DIFRENCIAR MAYUSCULAS MINISCULAS
        private void Button2_Click(object sender, EventArgs e)
        {

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

            //hacer palabrasresolver en char recorrerlo letra a letra diciendo si es igual a letraTextbox ,
            //guardar posiciones en int de array y asi con estas posiciones sabes donde poner esa letra determinada (letra que se repite)


            if (palabraReseolver.Contains(letraTextbox))
            {
                label1.Text = "";

                int posLetra = palabraReseolver.IndexOf(letraTextbox);
                //[posLetra]
                rayitas[posLetra] = letraTextbox;
                lblVdas.Text = "GG";
                label1.Text = "";
                for (int i = 0; i < rayitas.Length; i++)
                {
                    if (rayitas.Length - 1 == i)
                    {
                        palabraNueva += rayitas[i];
                    }
                    else
                    {
                        palabraNueva += rayitas[i] + "-";
                    }
                }
                label1.Text = palabraNueva;
                palabraNueva = "";
            }
            else
            {
                lblVdas.Text = "Paquete";
            }

        }
    }
}
