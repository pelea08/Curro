using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejer4Ev1
{
    class Program
    {
        static bool finalizar = false;
        static readonly object l = new object();
        static Random r = new Random();
        static int nAleatorio;
        static int contadorComun = 0;
        static bool finalizarBarra = true;
        static bool pausarBarra = true;
        static int nAleDormir;
        static void Main(string[] args)
        {
            ///Lo del 1 y el 20 es para difenciarlos.
            Thread player1 = new Thread(numeroAleatorios);
            player1.Start(1);
            Thread player2 = new Thread(numeroAleatorios);
            player2.Start(20);

            Thread display = new Thread(barra);
            display.Start();

            Console.ReadLine();
        }
        static void barra()
        {
            char[] simbolo = { '|', '/', '-', '\\' };
            int i = 0;
            while (finalizarBarra)
            {
                lock (l)
                {
                    if (pausarBarra)
                    {
                        Monitor.Wait(l);
                        i++;
                        if (i == simbolo.Length)
                        {
                            i = 0;
                        }
                        Console.SetCursorPosition(1, 15);
                        Console.Write(simbolo[i]);

                    }
                }
                Thread.Sleep(750);
            }
        }
        static void numeroAleatorios(object a)
        {
            while (!finalizar)
            {
                lock (l)
                {
                    if (!finalizar)
                    {
                        nAleatorio = r.Next(1, 11);
                        nAleDormir = r.Next(100, 101 * nAleatorio);
                      
                        if ((int)a == 1 && nAleatorio == 5 || nAleatorio == 7)
                        {
                            if (pausarBarra)
                            {
                                contadorComun += 1;
                                //Cuando esto pasa tienes que pausar la barra que gira
                                pausarBarra = false;
                            }
                            else
                            {
                                contadorComun += 5;
                            }
                        }
                        if ((int)a == 20 && nAleatorio == 5 || nAleatorio == 7)
                        {
                            if (!pausarBarra)
                            {
                                contadorComun -= 1;
                                //Cuando esto pasa tiene que guirar la barra
                                lock (l)
                                {
                                    pausarBarra = true;
                                    Monitor.Pulse(l);
                                }
                            }
                            else
                            {
                                contadorComun -= 5;
                            }
                        }
                        Console.SetCursorPosition(5, (int)a);
                        Console.WriteLine("{0,2}", nAleatorio);

                        if ((int)a == 1 && contadorComun > 14)
                        {
                            Console.SetCursorPosition(1, 25);
                            Console.WriteLine("Gano el jugador 1");
                            finalizar = true;

                        }
                        if ((int)a == 20 && contadorComun < -14)
                        {
                            Console.SetCursorPosition(1, 25);
                            Console.WriteLine("Gano el jugador 2");
                            finalizar = true;

                        }
                    }
                }
                Thread.Sleep(nAleDormir);
            }
        }
    }
}
