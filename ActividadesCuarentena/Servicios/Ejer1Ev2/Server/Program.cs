using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static bool finalizacion = true;
        static int puerto = 31416;

        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, puerto);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            bool verificar = false;
            do
            {
                try
                {
                    socket.Bind(ie);
                    socket.Listen(20);
                    verificar = true;
                }
                catch (SocketException)
                {
                    puerto++;
                    verificar = false;
                }
            } while (!verificar);

            Console.WriteLine("SE HA CONECTADO " + ie.Port);
            while (finalizacion)
            {
                Socket cliente = socket.Accept();

                using (NetworkStream ns = new NetworkStream(cliente))
                using (StreamWriter sw = new StreamWriter(ns))
                using (StreamReader sr = new StreamReader(ns))
                {
                    try
                    {
                        switch (sr.ReadLine())
                        {
                            case "HORA":
                                sw.WriteLine(DateTime.Now.ToString("hh:mm:ss tt"));
                                sw.Flush();
                                break;
                            case "FECHA":
                                sw.WriteLine(DateTime.Today.ToString("d"));
                                sw.Flush();
                                break;
                            case "TODO":
                                sw.WriteLine(DateTime.Now.ToString("hh:mm:ss tt") + DateTime.Today.ToString("d"));
                                sw.Flush();
                                break;
                            case "APAGAR":
                                finalizacion = false;
                                break;
                            default:
                                sw.WriteLine("ESA OPCION NO EXISTE EN ESTE SERVIDOR");
                                sw.Flush();
                                break;
                        }
                        if (!finalizacion)
                        {
                            cliente.Close();
                        }
                    }
                    catch (IOException)
                    {
                        break;
                    }
                }
            }
        }
    }
}
