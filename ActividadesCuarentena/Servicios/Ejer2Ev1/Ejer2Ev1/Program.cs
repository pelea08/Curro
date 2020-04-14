using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Ev1
{
    class Program
    {
        static void Main(string[] args)
        {
            int op = 0;

            do
            {
                try
                {
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("1.-Visualizar todos los procesos");
                    Console.WriteLine("2.-Información de un proceso");
                    Console.WriteLine("3.-Cierre de un proceso");
                    Console.WriteLine("4.-Cierre forzoso de un proceso");
                    Console.WriteLine("5.-Ejecucion de una aplicacion");
                    Console.WriteLine("6.-Guardar en archivo");
                    Console.WriteLine("7.-Leer archivo");
                    Console.WriteLine("8.-Salir");
                    op = Convert.ToInt32(Console.ReadLine());

                    switch (op)
                    {

                        case 1:
                            break;



                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Introduzca un número valido");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduzca números");
                }


            } while (op < 1 || op > 8);


        }
    }
}
