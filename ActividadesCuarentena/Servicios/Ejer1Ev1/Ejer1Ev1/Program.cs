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

                //Generar la aleatoriedad fuera ? y pasarla como paramentro n plan object 
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

//        Aquí veo aun varia cosas raras: Primero es que tropiezo solo se ejecuta una vez(no hay bucle cada 2 segundos). El caballo no se vuelve a poner normal a los dos segundos, si no en el siguiente turno(el true no se gestiona en tropiezo si no en el caballo). 
//Accedes a variables comnes sin lock.
//Accedes a la consola sin lock, esto hace que aparezcan asetriscos en sitios raros.
        static void tropiezo()
        {
            lock (l)
            {
                for (int i = 0; i < banderas.Length; i++)
                {
                    banderas[i] = true;
                }
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
            contadorSegundos++;
            //Pasados los 2 segundos se vuelve a poner normal
            //banderas[aleatorio] = true;
        }

        static void caballos(object caballo)
        {
            int dormirAleatorio = r.Next(100, 501);
            int i = 1;
            int distanciaAleatoria = r.Next(1, 4);

            while (!finalizacion)
            {
                int caballoActual = (int)caballo + 1;
                lock (l)
                {
                    Console.SetCursorPosition(i + 1, caballoActual);
                    Console.Write(" ");

                    int indiceBien = (int)caballo;
                    if (banderas[indiceBien])
                    {
                        i += distanciaAleatoria;
                        Console.SetCursorPosition(i + 1, caballoActual);
                        Console.Write("*");
                        banderas[(int)caballo] = true;

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
