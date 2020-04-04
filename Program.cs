using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Collections;

namespace Ejercicio4Networkin
{
    class Program
    {
        static int claveCierre = 1234;
        static bool bandera = true;
        static readonly object l = new object();




        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Bind(ie);
            s.Listen(20);
            Console.WriteLine("Conectado");
            while (bandera)
            {
                Socket cliente = s.Accept();
                Thread thread = new Thread(hiloCliente);
                thread.Start(cliente);
            }


        }

        static void hiloCliente(object cliente)
        {
            bool finalizacion = true;

            using (NetworkStream ns = new NetworkStream((Socket)cliente))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {

                String txt = sr.ReadLine();
                String[] troceo = txt.Split(' ');
                List<StreamWriter> almacen = new List<StreamWriter>();

                while (finalizacion)
                {
                    try
                    {
                        lock (l)
                        {
                            if (sw != null)
                            {
                                almacen.Add(sw);

                            }
                        }


                        if (!txt.Equals("") || !txt.Equals(null) || troceo.Length < 3)
                        {
                            if (txt.Equals("getword"))
                            {
                                lock (l)
                                {
                                    //ruta del homepath de marras
                                    using (StreamReader lectura = new StreamReader("C:/Users/User/Desktop/getword.txt"))
                                    {
                                        String[] conjuntoPalabras = lectura.ReadToEnd().Split('\n');
                                        int tamaño = conjuntoPalabras.Length;
                                        Random r = new Random();
                                        int numeroAleatorio = r.Next(0, tamaño);

                                        sw.WriteLine(conjuntoPalabras[numeroAleatorio]);
                                        sw.Flush();
                                    }
                                }
                            }
                            else if (txt.Equals("getrecords"))
                            {
                                lock (l)
                                {
                                    using (StreamReader srr = new StreamReader("C:/Users/User/Desktop/getrecords.txt"))
                                    {
                                        String[] texto = srr.ReadToEnd().Split('\n');
                                        ArrayList almacen2 = new ArrayList();
                                        for (int i = 0; i < texto.Length; i++)
                                        {
                                            //almacen1 += texto[i];
                                            sw.WriteLine(texto[i]);
                                            sw.Flush();
                                            //almacen2.Add(texto[i]);
                                        }
                                        //sw.WriteLine(almacen2);
                                        //sw.Flush();
                                    }
                                }
                            }
                            else if (troceo[0].Equals("sendword"))
                            {
                                lock (l)
                                {
                                    using (StreamWriter sww = new StreamWriter("C:/Users/User/Desktop/getword.txt", true))
                                    {
                                        sww.WriteLine(troceo[1]);
                                        sww.Flush();
                                    }
                                }
                            }
                            else if (troceo[0].Equals("sendrecord"))
                            {
                                lock (l)
                                {
                                    using (StreamWriter sww = new StreamWriter("C:/Users/User/Desktop/getrecords.txt", true))
                                    {
                                        IPAddress a;
                                        //falta verificacion
                                        if (troceo[1] != null && troceo[2] != null && troceo[3] != null)
                                        {
                                            try
                                            {
                                                if (Convert.ToInt32(troceo[1]) > 0)
                                                {
                                                    if (troceo[2].ToString().Length == 3)
                                                    {
                                                        if (IPAddress.TryParse(troceo[3],out a))
                                                        {
                                                            //revisar funcion ip
                                                            Console.WriteLine("g");
                                                            sww.WriteLine(troceo[1] + " " + troceo[2] + " " + troceo[3]);
                                                            sww.Flush();
                                                        }
                                                    }

                                                }

                                            }
                                            catch (FormatException)
                                            {

                                            }

                                            
                                        }
                                        else
                                        {

                                        }
                                    }
                                }
                            }
                            else if (troceo[0].Equals("closeserver"))
                            {
                                if (Convert.ToInt32(troceo[1]) == claveCierre)
                                {
                                    finalizacion = false;
                                }
                            }
                        }
                        finalizacion = false;

                    }
                    catch (IOException)
                    {
                        finalizacion = false;

                        break;
                    }
                }
                Console.WriteLine("CONEXIÓN FINALIZADA");
            }
        }
    }
}


