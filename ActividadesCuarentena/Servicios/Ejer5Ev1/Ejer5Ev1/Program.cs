using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ejer5Ev1
{
    class Program
    {
        static readonly object l = new object();
        static bool finalizacion = true;
        static bool finalizacion1 = true;
        static int stock = 100;
        static void Main(string[] args)
        {
            string[] nombres = { "Halcón Milenario", "Nostromo", "Discovery 1", "Lego Spaceship", " Gatobús" };

            Thread[] conjuntoNave = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                conjuntoNave[i] = new Thread(nave);
            }
            for (int j = 0; j < conjuntoNave.Length; j++)
            {
                conjuntoNave[j].Start(nombres[j]);
            }
            Thread gestionAlmacen = new Thread(gestorAlmacen);
            gestionAlmacen.Start();

            Console.ReadKey();
            lock (l)
            {
                finalizacion = false;
                finalizacion1 = false;
            }
            Console.WriteLine("El ultimo valor del stock es " + stock);
            Console.ReadKey();
        }
        static void gestorAlmacen()
        {
            while (finalizacion1)
            {
                lock (l)
                {
                    if (finalizacion1)
                    {
                        Monitor.Wait(l);

                        stock += 100;
                        Console.WriteLine("--------> Se ha aumentado el stock en 100 unidades, en total hay" + stock + " <--------");
                    }
                }
            }
        }
        static void nave(object nombre)
        {
            Random r = new Random();
            int aleatorio = r.Next(0, 3);
            while (finalizacion)
            {
                lock (l)
                {
                    if (finalizacion)
                    {
                        //No gestiones 2 veces el cero no tiene sentido porque en el momento que cambie en el transcurso del proceso liadisima
                        if (stock == 0)
                        {
                            Console.WriteLine((string)nombre + " no puede cargar por falta de stock avisa y se va");
                            Monitor.Pulse(l);
                        }
                        else
                        {
                            if (aleatorio == 0)
                            {
                                stock -= 50;
                                Console.WriteLine((string)nombre + " ha quitado 50 unidades, quedan" + stock + " en el almacen");
                            }
                            else
                            {
                                stock += 50;
                                Console.WriteLine((string)nombre + " ha  agregado 50 unidades, quedan" + stock + " en el almacen");
                            }
                        }
                    }
                }
                Thread.Sleep(2000);
            }
        }
    }
}
