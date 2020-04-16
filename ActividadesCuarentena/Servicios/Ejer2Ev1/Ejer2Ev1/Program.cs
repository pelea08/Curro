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
        static string ruta;

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
                            Process[] processes = Process.GetProcesses();
                            foreach (Process process in processes)
                            {
                                Console.WriteLine("Name: " + process.ProcessName + " ID: " + process.Id + " Titulo Ventana: " + process.MainWindowTitle);
                            }
                            break;
                        case 2:
                            int proceso;
                            do
                            {
                                Console.WriteLine("Introduzca un numero de proceso");
                                proceso = Convert.ToInt32(Console.ReadLine());

                            } while (proceso < 0 || proceso > 65555);

                            Process p = Process.GetProcessById(proceso);
                            //OJO EXCEPCION WIN 32
                            ProcessModule processModule = p.MainModule;
                            Console.WriteLine("Name: " + p.ProcessName + " ID: " + p.Id + " Titulo Ventana: " + p.MainWindowTitle + " Nombre Modulo: " + processModule.ModuleName + " Nombre del archivo: " + processModule.FileName);
                            break;
                        case 3:
                            int proceso2;
                            do
                            {
                                Console.WriteLine("Introduzca un numero de proceso");
                                proceso2 = Convert.ToInt32(Console.ReadLine());

                            } while (proceso2 < 0 || proceso2 > 65555);
                            Process p2 = Process.GetProcessById(proceso2);
                            p2.CloseMainWindow();
                            Console.WriteLine("Se ha cerrado correctamente");

                            break;
                        case 4:
                            int proceso1;
                            do
                            {
                                Console.WriteLine("Introduzca un numero de proceso");
                                proceso1 = Convert.ToInt32(Console.ReadLine());

                            } while (proceso1 < 0 || proceso1 > 65555);
                            Process p1 = Process.GetProcessById(proceso1);
                            p1.Kill();
                            Console.WriteLine("Se ha cerrado correctamente");
                            break;

                        case 5:
                            string nombrePath;
                            Console.WriteLine("Introduce una ruta para ejecutar una app");
                            nombrePath = Console.ReadLine();
                            Process p3 = Process.Start(nombrePath);

                            break;
                        case 6:
                            Console.WriteLine("Introduzca una ruta para guardar el archivo");
                            ruta = Console.ReadLine();
                            using (StreamWriter sw = new StreamWriter(ruta))
                            {
                                Process[] processes2 = Process.GetProcesses();
                                foreach (Process process in processes2)
                                {
                                    sw.WriteLine("Name: " + process.ProcessName + " ID: " + process.Id);
                                }

                            }
                            break;
                        case 7:
                            using (StreamReader sr = new StreamReader(ruta))
                            {
                                Console.WriteLine(sr);
                            }
                            break;

                        case 8:
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
