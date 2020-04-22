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

        static int nAleDormir;
        static void Main(string[] args)
        {
            ///Lo del 1 y el 20 es para difenciarlos.
            Thread player1 = new Thread(numeroAleatorios);
            player1.Start(1);
            Thread player2 = new Thread(numeroAleatorios);
            player2.Start(20);

            //Thread display;
        }
        static void numeroAleatorios(object a)
        {
            //int nAleDormir = r.Next(99, 100 * nAleatorio);
            while (!finalizar)
            {
                lock (l)
                {
                    if (!finalizar)
                    {
                        nAleatorio = r.Next(1, 11);
                        nAleDormir = r.Next(99, 100 * nAleatorio);
                        Console.SetCursorPosition(5, (int)a);
                        Console.WriteLine("{0,2}", nAleatorio);
                    }
                }
                Thread.Sleep(nAleDormir);
            }
        }
    }
}
