﻿using System;
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
        static readonly object l = new object();
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

                String txt = sr.ReadLine();
                String[] troceo = txt.Split(' ');
                while (finalizacion)
                {
                    try
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
                                    for (int i = 0; i < texto.Length; i++)
                                    {
                                        sw.WriteLine(texto[i] + "\n");
                                        sw.Flush();
                                    }


                                }
                            }

                        }
                        else if (troceo[0].Equals("sendword"))
                        {
                            using (StreamWriter sww = new StreamWriter("C:/Users/User/Desktop/getword.txt", true))
                            {
                                sww.WriteLine(troceo[1]);
                                sww.Flush();
                            }


                        }
                        else if (troceo[0].Equals("sendrecord"))
                        {

                        }
                        else if (troceo[0].Equals("closerver")) {

                        }
                    }
                    catch (IOException)
                    {

                    }
                    finalizacion = false;

                }

            }

        }
    }
}
