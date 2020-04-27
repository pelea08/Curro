using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
            Funciones f = new Funciones();
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
                            f.visualizarTodo();
                            break;
                        case 2:
                            f.infoProceso();
                            break;
                        case 3:
                            f.cierre();
                            break;
                        case 4:
                            f.cierreForzoso();
                            break;
                        case 5:
                            f.ejecutarAplicacion();
                            break;
                        case 6:
                            f.guardarArchivo();
                            break;
                        case 7:
                            f.leerArchivo();
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
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Introduzca una ruta o app adecuada");
                }
                catch (Win32Exception)
                {
                    Console.WriteLine("Ruta o aplicación no existe");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("No hay archivo cargado");
                }
            } while (op != 8);

            Console.ReadLine();
        }
    }
}
