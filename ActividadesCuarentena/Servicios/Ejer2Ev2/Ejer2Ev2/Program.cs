using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Timers;
using System.Collections;

namespace Ejer2Ev2
{
    class Program
    {
        //OJO LO DEL TIMER
        private static System.Timers.Timer temporizador;
        static List<StreamWriter> almacenStreamWriter = new List<StreamWriter>();
        static readonly object l = new object();
        static List<int> nRepartir = new List<int>();
        static int contadorJugadores = 0;
        static int nPersonal;
        static Random r = new Random();
        static int contadorSegundos = 10;
        static int nMayor = 0;
        static bool banderaRestarTiempo = false;
        static Hashtable almacenJugadores = new Hashtable();
        static bool banderaFinalizacion = false;
        static void Main(string[] args)
        {
            int puerto = 31416;
            bool verificarPuerto = false;
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, puerto);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            do
            {
                try
                {
                    ie = new IPEndPoint(IPAddress.Any, puerto);
                    socket.Bind(ie);
                    verificarPuerto = true;
                }
                catch (SocketException)
                {
                    puerto++;
                    verificarPuerto = false;
                }
            } while (!verificarPuerto);

            socket.Listen(20);

            //Establecer Temporizador
            temporizador = new System.Timers.Timer(1000);
            temporizador.Elapsed += OnTimedEvent;

            Console.WriteLine("CONECTADO AL PUERTO: " + ie.Port);
            nRepartir = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                nRepartir.Add(i);
            }
            while (true)
            {
                Socket cliente = socket.Accept();

                Thread hilo = new Thread(hiloCliente);
                hilo.Start(cliente);
                if (banderaFinalizacion)
                {
                    reiniciar();
                }

                contadorJugadores++;
                if (contadorJugadores > 1)
                {
                    //Ejecutar el proceso de la cuenta atras en el cual ya comparamos y sabemos quien gana
                    temporizador.Start();
                }
            }
        }
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            banderaFinalizacion = false;
            banderaRestarTiempo = true;
            contadorSegundos--;

            if (contadorSegundos == 0)
            {
                temporizador.Stop();
                lock (l)
                {
                    foreach (DictionaryEntry dictionaryEntry in almacenJugadores)
                    {
                        StreamWriter jugadorSw = (StreamWriter)dictionaryEntry.Value;
                        try
                        {

                            if (nMayor == (int)dictionaryEntry.Key)
                            {
                                jugadorSw.WriteLine("ENHORABUENA ERES EL GANADOR CON EL NUMERO: " + nMayor);
                                jugadorSw.Flush();
                            }
                            else
                            {
                                jugadorSw.WriteLine("HAS PERDIDO, TU NUMERO ES EL: " + (int)dictionaryEntry.Key + " y el ganador fue " + nMayor);
                                jugadorSw.Flush();
                            }
                        }
                        catch (IOException)
                        {
                        }

                    }
                    Monitor.Pulse(l);
                }
            }
            else
            {
                lock (l)
                {
                    foreach (DictionaryEntry dictionaryEntry in almacenJugadores)
                    {
                        StreamWriter jugadorSw = (StreamWriter)dictionaryEntry.Value;

                        try
                        {
                            jugadorSw.WriteLine("Cuenta Atras: " + contadorSegundos);
                            jugadorSw.Flush();
                        }
                        catch (IOException)
                        {
                        }
                    }
                }
            }
        }
        static void hiloCliente(object socket)
        {
            Socket s = (Socket)socket;
            IPEndPoint point = (IPEndPoint)s.RemoteEndPoint;

            using (NetworkStream ns = new NetworkStream(s))
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {
                //No siempre es necesario while ACUERDATE
                sw.WriteLine("Bienvenidos al gran juego");
                sw.Flush();
                lock (l)
                {
                    if (sw != null)
                    {
                        almacenStreamWriter.Add(sw);

                        nPersonal = nRepartir[r.Next(nRepartir.Count)];
                        if (nPersonal > nMayor)
                        {
                            nMayor = nPersonal;
                        }
                        nRepartir.Remove(nPersonal);
                        almacenJugadores.Add(nPersonal, sw);
                        sw.WriteLine("Te ha tocado el " + nPersonal);
                        sw.Flush();
                        //Ojo aqui finalizamos asunto
                        Monitor.Wait(l);
                        banderaFinalizacion = true;
                    }
                }
            }
            s.Close();
        }
        static void reiniciar()
        {
            almacenStreamWriter = new List<StreamWriter>();
            contadorJugadores = 0;
            contadorSegundos = 10;
            nMayor = 0;
            banderaRestarTiempo = false;
            almacenJugadores = new Hashtable();
            banderaFinalizacion = false;
            temporizador.Stop();
        }
    }
}


