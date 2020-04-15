﻿using System;
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
        static Timer timer;
        static int apuesta;
        static bool[] banderas = new bool[6];

        static void Main(string[] args)
        {
            Thread tropezar;

            int repetir = 1;

            Random r = new Random();
            int diez = r.Next(1, 10);
            int distancia = diez;
            int tiempo = diez;

            while (repetir == 1)
            {
                //Console.Clear();
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
                        Console.WriteLine("Introduzca números no letras");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("Introduzca un número valido entre el 1 y el 5");
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

                //tropezar = new Thread(tropiezo);
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
                Thread.Sleep(2000);

                lock (l)
                {


                    for (int i = 0; i < banderas.Length; i++)
                    {
                        banderas[i] = true;
                    }

                    //El wait lo lógico es que sea aqui no antes
                    Monitor.Wait(l);
                    if (apuesta == ganador)
                    {
                        Console.SetCursorPosition(1, 23);
                        Console.Write("ENHORABUENA GANASTE\n");
                    }
                    else
                    {
                        Console.SetCursorPosition(1, 23);
                        Console.Write(apuesta + " HAS PERDIDO EL GANADOR ES EL NUMERO " + ganador + "\n");
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



        //static void tropiezo(object a)
        //{
        //    for (int i = 0; i < banderas.Length; i++)
        //    {
        //        banderas[i] = true;
        //    }

        //    Random rr = new Random();
        //    int aleatorio = rr.Next(0, banderas.Length);
        //    lock (l)
        //    {
        //        banderas[aleatorio] = false;
        //        Console.SetCursorPosition(1, 17);
        //        Console.WriteLine("Se acaba de detener el caballo numero" + (aleatorio + 1));
        //    }
        //    Thread.Sleep(2000);
        //}
        static void caballos(object caballo)
        {
            Random r = new Random();
            int dormirAleatorio = r.Next(200, 1000);
            int distanciaAleatoria = r.Next(1, 20);
            int i = 1;

            while (!finalizacion)
            {
                int caballoActual = (int)caballo + 1;
                lock (l)
                {
                    int proba = i - 1;
                    if (banderas[proba])
                    {
                        Console.SetCursorPosition(1 + i, caballoActual);
                        Console.Write("*");
                        i++;

                        if (i == 5)
                        {
                            finalizacion = true;
                            ganador = caballoActual;
                            Monitor.Pulse(l);
                            //intersante al llegar aqui implica finalizacion es decir plantearse pulse 
                        }
                    }
                }
                //ojo poner variable aleatorio
                Thread.Sleep(125);
            }

        }
    }
}
