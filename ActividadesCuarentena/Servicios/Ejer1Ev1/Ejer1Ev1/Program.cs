using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejer1Ev1
{
    class Program
    {
        static bool finalizacion = false;
        static readonly object l = new object();
        static void Main(string[] args)
        {

            Random r = new Random();
            int diez = r.Next(1, 10);
            int distancia = diez;
            int tiempo = diez;

            Thread[] participantes = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                participantes[i] = new Thread(caballos);
            }
            for (int j = 0; j < participantes.Length; j++)
            {
                participantes[j].Start(j);
            }



        }
        static void caballos(object caballo)
        {
            int i = 0;

            while (!finalizacion)
            {
                lock (l)
                {
                    Console.SetCursorPosition(1+i, (int)caballo + 1);
                    Console.Write("*");
                    i++;

                    if (i == 30)
                    {
                        finalizacion = true;
                    }




                }








            }


            Console.ReadLine();
        }
    }
}
