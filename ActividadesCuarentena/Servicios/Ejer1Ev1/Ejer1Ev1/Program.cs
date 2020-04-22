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
        static int ganador;
        static int apuesta;
        static bool[] banderas = new bool[5];
        static Random r = new Random();
        static int distanciaAleatoria = r.Next(1, 10);

        static void Main(string[] args)
        {
            int repetir = 1;
            while (repetir == 1)
            {
                finalizacion = false;
                repetir = 2;
                do
                {
                    try
                    {
                        Console.WriteLine("Apueste por un caballo del 1 al 5");
                        apuesta = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                    }
                    catch (OverflowException)
                    {
                    }
                } while (apuesta < 1 || apuesta > 5);

                Console.Clear();

                Thread[] conjuntoCaballos = new Thread[5];
                for (int i = 0; i < 5; i++)
                {
                    conjuntoCaballos[i] = new Thread(caballos);
                }
                for (int j = 0; j < conjuntoCaballos.Length; j++)
                {
                    conjuntoCaballos[j].Start(j);
                }
                Thread tropezar = new Thread(tropiezo);
                tropezar.Start();

                lock (l)
                {
                    Monitor.Wait(l);
                    if (apuesta == ganador)
                    {
                        Console.SetCursorPosition(1, 23);
                        Console.Write(apuesta + "ENHORABUENA GANASTE\n");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 23);
                        Console.Write("HAS PERDIDO EL GANADOR ES EL NUMERO " + ganador + "\n");
                    }
                    bool band = false;
                    do
                    {
                        try
                        {
                            Console.WriteLine("Desea volver a jugar 1-Si 2-No");
                            repetir = Convert.ToInt32(Console.ReadLine());
                            Console.Clear();
                            band = false;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduzca números no letras");
                            band = true;
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Introduzca un número valido entre el 1 y el 5");
                            band = true;
                        }

                    } while (repetir < 1 || repetir > 2 || band);
                }
            }
            Console.ReadLine();
        }

        static void tropiezo()
        {
            //Inicializamos todo a true
            for (int i = 0; i < banderas.Length; i++)
            {
                banderas[i] = true;
            }

            Random rr = new Random();
            int aleatorio = rr.Next(0, banderas.Length);
            lock (l)
            {
                banderas[aleatorio] = false;
                Console.SetCursorPosition(1, 17);
                Console.WriteLine("Se acaba de detener el caballo numero" + (aleatorio + 1));
            }
            Thread.Sleep(4000);
            //Pasados los 4 segundos se vuelve a poner normal
            banderas[aleatorio] = true;
        }

        static void caballos(object caballo)
        {
            int dormirAleatorio = r.Next(1000, 2000);
            int i = 1;
            while (!finalizacion)
            {
                int caballoActual = (int)caballo + 1;

                Console.SetCursorPosition(i + 1, caballoActual);
                Console.Write(" ");
                lock (l)
                {
                    int indiceBien = (int)caballo;
                    if (banderas[indiceBien])
                    {
                        i += distanciaAleatoria;
                        Console.SetCursorPosition(i + 1, caballoActual);
                        Console.Write("*");

                        if (i >= 50)
                        {
                            finalizacion = true;
                            ganador = caballoActual;
                            Monitor.Pulse(l);
                        }
                    }
                }
                Thread.Sleep(dormirAleatorio);
            }
        }
    }
}
