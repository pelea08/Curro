using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Ejercicio4Networkin
{
    class Program
    {
        static bool bandera = true;
        static bool finalizacion = true;
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ie);
            s.Listen(20);

            while (bandera)
            {
                Socket cliente = s.Accept();
                Thread thread = new Thread(hiloCliente);
                thread.Start(cliente);
            }


        }

        static void hiloCliente(object cliente)
        {

            using (NetworkStream ns = new NetworkStream((Socket)cliente))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {

               
                while (finalizacion)
                {
                    if (sr.ReadLine().Equals("getword"))
                    {
                        using (StreamReader lectura = new StreamReader("C:/Users/User/Desktop/getword.txt")) {
                            String[] conjuntoPalabras = lectura.ReadToEnd().Split('\n');
                            int tamaño = conjuntoPalabras.Length;
                            Random r = new Random();
                            int numeroAleatorio = r.Next(0, tamaño);
                            sw.WriteLine(conjuntoPalabras[numeroAleatorio]);
                            sw.Flush();

                        }



                    }
                   






                }

            }

        }
    }
}
