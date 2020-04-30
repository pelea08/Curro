using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejer3Ev2
{
    class Sala
    {
        static readonly object l = new object();
        static bool finalizacion = true;
        static List<Socket> almacenClientes = new List<Socket>();
        static List<StreamWriter> almacenStream = new List<StreamWriter>();
        static List<int> almacenPuerto = new List<int>();
        int puerto = 0;
        bool puertoCorrecto = false;
        static Socket a;
        static bool banderaSw = false;

        public int leerPuerto()
        {
            using (StreamReader sr = new StreamReader("C:/Windows/Temp/puerto.txt"))
            {
                try
                {
                    puerto = Convert.ToInt32(sr.ReadLine());
                }
                catch (FormatException)
                {
                    puertoCorrecto = false;
                }
                if (puerto > 0 && puerto < 65535)
                {
                    puertoCorrecto = true;
                }
            }
            if (!puertoCorrecto)
            {
                puerto = 10000;
            }
            return puerto;
        }
        public void envioMensaje(string m, IPEndPoint ie)
        {
            foreach (Socket socket in almacenClientes)
            {
                a = socket;
            }

            using (NetworkStream ns = new NetworkStream(a))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {
                lock (l)
                {
                    //Almacen puerto y stream siempre van a tener el mismo tamaño
                    for (int i = 0; i < almacenStream.Count; i++)
                    {

                        if (!almacenStream[i].Equals(sw) & ie.Port != almacenPuerto[i])
                        {
                            almacenStream[i].WriteLine("IP: " + ie.Address + " Puerto: " + ie.Port + " Mensaje: " + m);
                            almacenStream[i].Flush();
                            //banderas = true;
                        }



                    }
                }
            }
        }
        public void inicioServicioChat()
        {
            bool banderaPuerto = false;
            int puerto = leerPuerto();
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, puerto);
            Socket ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            do
            {
                try
                {
                    ie = new IPEndPoint(IPAddress.Any, puerto);
                    ss.Bind(ie);
                    ss.Listen(20);
                    banderaPuerto = true;
                    Console.WriteLine("Puerto: " + ie.Port + " IP:" + ie.Address);
                }
                catch (SocketException)
                {
                    puerto++;
                    banderaPuerto = false;
                }
            } while (!banderaPuerto);

            while (true)
            {
                Socket cliente = ss.Accept();
                almacenClientes.Add(cliente);

                Thread hilo = new Thread(hiloCliente);
                hilo.Start(cliente);
            }

        }
        public void hiloCliente(object socket)
        {

            string mensaje;
            Socket cliente = (Socket)socket;
            IPEndPoint ie = (IPEndPoint)cliente.RemoteEndPoint;

            Console.WriteLine("IP Cliente: " + ie.Address + " Puerto Cliente: " + ie.Port);
            using (NetworkStream ns = new NetworkStream(cliente))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {

                almacenStream.Add(sw);
                //IP DE CADA PERSONA QUE SE CONECTA
                almacenPuerto.Add(ie.Port);
                sw.WriteLine("Bienvenidos al gran ejercicio hay " + almacenStream.Count + " personas conectadas");
                sw.Flush();

                while (finalizacion)
                {
                    try
                    {
                        mensaje = sr.ReadLine();
                        if (mensaje != "" && mensaje != "MELARGO" & mensaje != null)
                        {
                            envioMensaje(mensaje, ie);
                        }
                        else if (mensaje == "MELARGO" || mensaje == null)
                        {
                            cliente.Close();
                            almacenStream.Remove(sw);
                            almacenClientes.Remove(cliente);
                            almacenPuerto.Remove(ie.Port);
                        }
                    }
                    catch (IOException)
                    {
                        cliente.Close();
                        almacenStream.Remove(sw);
                        almacenClientes.Remove(cliente);
                        almacenPuerto.Remove(ie.Port);
                    }
                }
            }
        }
    }
}
