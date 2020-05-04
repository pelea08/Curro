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
        static List<int> almacenPuerto = new List<int>();
        int puerto = 0;
        bool puertoCorrecto = false;

        public int leerPuerto()
        {
            try
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
            }
            catch (FileNotFoundException)
            {
                puerto = 10000;

            }
            return puerto;
        }
        public void envioMensaje(string m, IPEndPoint ie)
        {
            foreach (Socket socket in almacenClientes)
            {
                using (NetworkStream ns = new NetworkStream(socket))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    lock (l)
                    {
                        IPEndPoint endPoint = (IPEndPoint)socket.RemoteEndPoint;
                        if (ie.Port != endPoint.Port)
                        {
                            sw.WriteLine("IP: " + ie.Address + " Puerto: " + ie.Port + " Mensaje: " + m);
                            sw.Flush();
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
                almacenPuerto.Add(ie.Port);
                sw.WriteLine("Bienvenidos al gran ejercicio hay " + almacenClientes.Count + " personas conectadas");
                sw.Flush();

                while (finalizacion)
                {
                    lock (l)
                    {
                        if (finalizacion)
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
                                    finalizacion = false;
                                    break;
                                }
                            }
                            catch (IOException)
                            {
                                finalizacion = false;
                                break;
                            }
                        }
                    }
                }
                if (!finalizacion)
                {
                    cliente.Close();
                    almacenClientes.Remove(cliente);
                    almacenPuerto.Remove(ie.Port);
                }

            }
        }
    }
}
