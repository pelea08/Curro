using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Ejer4Ev2
{
    public class ServidorArchivos
    {
        static bool finalizacion = true;

        //MEtodos publicos NO estaticos
        public string leeArchivo(string nombreArchivo, int nLineas)
        {
            int cont = 0;
            string texto = "";
            StreamReader sr;
            try
            {
                using (sr = new StreamReader(Environment.GetEnvironmentVariable("EXAMEN") + "\\" + nombreArchivo))
                {
                    while (cont != nLineas)
                    {
                        string lectura = sr.ReadLine();

                        if (lectura == null)
                        {
                            break;
                        }

                        texto += "\n" + lectura;
                        cont++;
                    }
                    if (cont < nLineas)
                    {
                        texto = "";
                        //Si usaba el otro StreamReader no me cogia nada y depure e hice bastantes pruebas y esa fue la solucion que se me ocurrio
                        using (StreamReader sr1 = new StreamReader(Environment.GetEnvironmentVariable("EXAMEN") + "\\" + nombreArchivo))
                            texto = sr1.ReadToEnd();
                    }
                    return texto;
                }
            }
            catch (FileNotFoundException)
            {
                return "< ERROR_IO >";
            }
        }
        public int leePuerto()
        {
            int puerto = 0;
            try
            {
                puerto = Convert.ToInt32(leeArchivo("puerto.txt", 1));
                if (puerto < 0 | puerto > 65535)
                {
                    puerto = 31416;
                }
            }
            catch (FormatException)
            {
                puerto = 31416;
            }
            return puerto;
        }
        public void guardaPuerto(int numero)
        {
            using (StreamWriter sw = new StreamWriter(Environment.GetEnvironmentVariable("EXAMEN") + "\\" + "puerto.txt", false))
            {
                sw.WriteLine(numero.ToString());
            }
        }
        public string listaArchivos()
        {
            DirectoryInfo d = new DirectoryInfo(Environment.GetEnvironmentVariable("EXAMEN"));
            string valor = "";
            foreach (FileInfo fileInfo in d.GetFiles())
            {
                if (fileInfo.Extension == ".txt")
                {
                    valor += fileInfo.Name + "\n";
                }
            }
            return valor;
        }

        public void iniciarServidorArchivos()
        {
            try
            {
                IPEndPoint ie = new IPEndPoint(IPAddress.Any, leePuerto());
                Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                s.Bind(ie);
                s.Listen(20);
                Console.WriteLine("Puerto de Conexion " + ie.Port);

                while (true)
                {
                    Socket cliente = s.Accept();

                    Thread hilo = new Thread(hiloCliente);
                    hilo.Start(cliente);
                }
            }
            catch (SocketException)
            {
                Console.WriteLine("PUERTO OCUPADO");
            }
        }
        public void hiloCliente(object socket)
        {
            string mensaje = "";
            Socket s = (Socket)socket;
            IPEndPoint ie = (IPEndPoint)s.RemoteEndPoint;

            //s.Connect(ie);
            Console.WriteLine("IP: " + ie.Address + " Puerto: " + ie.Port);
            using (NetworkStream ns = new NetworkStream(s))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {
                sw.WriteLine("Conexion Establecida");
                sw.Flush();
                while (finalizacion)
                {
                    try
                    {
                        mensaje = sr.ReadLine();
                        string[] troceo = mensaje.Split(' ');

                        switch (troceo[0])
                        {
                            case "GET":
                                sw.WriteLine(leeArchivo(troceo[1], Convert.ToInt32(troceo[2])));
                                sw.Flush();
                                break;

                            case "PORT":
                                guardaPuerto(Convert.ToInt32(troceo[1]));
                                break;

                            case "LIST":
                                sw.WriteLine(listaArchivos());
                                sw.Flush();
                                break;

                            case "CLOSE":
                                s.Close();
                                break;

                            case "HALT":
                                finalizacion = false;
                                Environment.Exit(0);
                                break;
                        }
                    }
                    catch (IOException)
                    {

                    }
                    catch (FormatException)
                    {
                        sw.WriteLine("Introduzca el formato de los comandos adecuados");
                        sw.Flush();
                    }

                }

            }

        }
    }
}
