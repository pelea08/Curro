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
        int puerto = 0;
        bool puertoCorrecto = false;
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

                socket.Connect(ie);

                using (NetworkStream ns = new NetworkStream(socket))

                using (StreamWriter sw = new StreamWriter(ns))
                using (StreamReader sr = new StreamReader(ns))
                {
                    while (finalizacion)
                    {
                        //Añadimos cada persona que entra para evitar repeticion mensaje
                        lock (l)
                        {
                            for (int i = 0; i < almacenStream.Count; i++)
                            {
                                //Enviale el mensaje a todos menos a mi mismo
                                if (almacenStream[i] != sw)
                                {
                                    sw.WriteLine("IP: " + ie.Address + " Puerto: " + ie.Port + " Mensaje: " + m);
                                    sw.Flush();
                                }
                            }
                        }
                    }

                }
            }

        }
        public void inicioServicioChat()
        {
            //Coger excepcion puerto ocupado , se incrementa
            bool banderaPuerto = false;
            int puerto = leerPuerto();
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, puerto);
            Socket ss = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            do
            {
                try
                {
                    ie = new IPEndPoint(IPAddress.Loopback, puerto);
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
                //for (int i = 0; i < almacenClientes.Count; i++)
                //{
                Socket s = ss.Accept();
                almacenClientes.Add(s);

                Thread hilo = new Thread(hiloCliente);
                hilo.Start(s);

                //}

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
                sw.WriteLine("Bienvenidos al gran ejercicio hay " + almacenClientes.Count + " personas conectadas");
                sw.Flush();
                almacenStream.Add(sw);
                while (finalizacion)
                {
                    //lock (l)
                    //{
                    mensaje = sr.ReadLine();
                    switch (mensaje)
                    {
                        case "MELARGO":
                            cliente.Close();
                            almacenStream.Remove(sw);
                            break;
                        default:
                            envioMensaje(sr.ReadLine(), ie);
                            break;

                    }
                    //if (mensaje == "MELARGO")
                    //{
                    //    cliente.Close();
                    //    almacenStream.Remove(sw);
                    //}
                    //else if (mensaje != "")
                    //{
                    //    envioMensaje(sr.ReadLine(), ie);

                    //}
                    //}
                }
            }
        }
    }
}
