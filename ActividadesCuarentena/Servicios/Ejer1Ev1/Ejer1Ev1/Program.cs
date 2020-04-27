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
        static int contadorSegundos = 0;
        static int aleatorio;
        static Random rr;
        static bool banderasVerificar = false;
        static void Main(string[] args)
        {
            int repetir = 1;
            while (repetir == 1)
            {
                lock (l)
                {
                    finalizacion = false;
                    repetir = 2;
                    do
                    {
                        try
                        {
                            Console.Clear();
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

                }

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
                            band = false;
                            if (repetir == 2)
                            {
                                Environment.Exit(0);
                            }
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
            while (contadorSegundos % 1 == 0)
            {
                rr = new Random();
                aleatorio = rr.Next(0, banderas.Length);
                lock (l)
                {
                    if (banderas[aleatorio])
                    {
                        banderas[aleatorio] = false;

                        Console.SetCursorPosition(1, 17);
                        Console.WriteLine("Se acaba de detener el caballo numero " + (aleatorio + 1));
                    }
                }
                Thread.Sleep(2000);
                contadorSegundos++;
            }
        }

        static void caballos(object caballo)
        {
            int dormirAleatorio = r.Next(100, 501);
            int i = 1;
            int distanciaAleatoria = r.Next(1, 4);

            if (!banderasVerificar)
            {
                for (int k = 0; k < banderas.Length; k++)
                {
                    banderas[k] = true;
                }
                banderasVerificar = true;
            }

            while (!finalizacion)
            {
                int caballoActual = (int)caballo + 1;
                lock (l)
                {

                    int indiceBien = (int)caballo;
                    if (banderas[indiceBien])
                    {
                        Console.SetCursorPosition(i + 1, caballoActual);
                        Console.Write(" ");

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
                    else
                    {
                        banderas[aleatorio] = true;
                        
                    }
                }
                Thread.Sleep(dormirAleatorio);
            }
        }
    }
}
