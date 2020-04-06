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
        public static bool finLectura = false;
        //static bool finalizacion = true;

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
                        if (txt != "" || txt != null || troceo.Length < 3)
                        {


                            if (txt == "getword")
                            {
                                lock (l)
                                {
                                    //ruta del homepath de marras
                                    //Environment.GetEnvironmentVariable("homepath") + "\\" + "Desktop"
                                    using (StreamReader lectura = new StreamReader(Environment.GetEnvironmentVariable("homepath") + "\\" + "Desktop" + "\\" + "getword.txt"))
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
                            else if (txt == "getrecords")
                            {
                                lock (l)
                                {
                                    using (StreamReader srr = new StreamReader(Environment.GetEnvironmentVariable("homepath") + "\\" + "Desktop" + "\\" + "getrecords.txt"))
                                    {
                                        String[] texto = srr.ReadToEnd().Split('\n');
                                        for (int i = 0; i < texto.Length; i++)
                                        {
                                            sw.WriteLine(" " + texto[i] + "  ");
                                            sw.Flush();
                                        }
                                        sw.WriteLine("#finarchivo");
                                        sw.Flush();
                                    }
                                }
                            }
                            else if (troceo[0] == "sendword")
                            {
                                lock (l)
                                {
                                    using (StreamWriter sww = new StreamWriter(Environment.GetEnvironmentVariable("homepath") + "\\" + "Desktop" + "\\" + "getword.txt", true))
                                    {
                                        sww.WriteLine(troceo[1]);
                                        sww.Flush();
                                    }
                                }
                            }
                            else if (troceo[0] == "sendrecord")
                            {
                                lock (l)
                                {
                                    using (StreamWriter sww = new StreamWriter(Environment.GetEnvironmentVariable("homepath") + "\\" + "Desktop" + "\\" + "getrecords.txt", true))
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
                                                        if (IPAddress.TryParse(troceo[3], out a))
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
                                    }
                                }
                            }
                            else if (troceo[0] == "closeserver")
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


