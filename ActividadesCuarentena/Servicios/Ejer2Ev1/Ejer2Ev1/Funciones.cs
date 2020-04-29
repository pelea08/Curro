using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Ev1
{
    class Funciones
    {
        static string ruta;
        public void visualizarTodo()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                Console.WriteLine("Name: " + process.ProcessName + " ID: " + process.Id + " Titulo Ventana: " + process.MainWindowTitle);
            }
        }
        public void leerArchivo()
        {
            using (StreamReader sr = new StreamReader(ruta))
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
        public void guardarArchivo()
        {
            bool banderaArchivo = false;
            do
            {
                Console.WriteLine("Introduzca una ruta para guardar el archivo");
                ruta = Console.ReadLine();
                try
                {
                    using (StreamWriter sw = new StreamWriter(ruta))
                    {
                        Process[] processes2 = Process.GetProcesses();
                        foreach (Process process in processes2)
                        {
                            sw.WriteLine("Name: " + process.ProcessName + " ID: " + process.Id);
                            banderaArchivo = true;
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Ruta incorrecta,introduzca una ruta valida de un archivo");
                    banderaArchivo = false;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ruta incorrecta,introduzca una ruta valida de un archivo");
                    banderaArchivo = false;
                }
                catch (UnauthorizedAccessException) {
                    Console.WriteLine("Ruta incorrecta,introduzca una ruta valida de un archivo");
                    banderaArchivo = false;
                }
            } while (!banderaArchivo);
        }
        public void ejecutarAplicacion()
        {
            string nombrePath;
            Console.WriteLine("Introduce una ruta para ejecutar una app");
            nombrePath = Console.ReadLine();
            Process p3 = Process.Start(nombrePath);
        }
        public void cierreForzoso()
        {
            int proceso1 = 0;
            do
            {
                try
                {
                    Console.WriteLine("Introduzca un numero de proceso");
                    proceso1 = Convert.ToInt32(Console.ReadLine());
                    Process p1 = Process.GetProcessById(proceso1);
                    p1.Kill();
                    Console.WriteLine("Se ha cerrado correctamente");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Numero de proceso incorrecto");
                }

            } while (proceso1 < 0 || proceso1 > 65555);
        }
        public void cierre()
        {
            int proceso2;
            do
            {
                Console.WriteLine("Introduzca un numero de proceso");
                proceso2 = Convert.ToInt32(Console.ReadLine());

                try
                {
                    Process p2 = Process.GetProcessById(proceso2);
                    p2.CloseMainWindow();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Numero de proceso incorrecto");
                }
            } while (proceso2 < 0 || proceso2 > 65555);
        }
        public void infoProceso()
        {
            int proceso = 0;
            bool verificar = false;
            do
            {
                Console.WriteLine("Introduzca un numero de proceso");
                proceso = Convert.ToInt32(Console.ReadLine());
                try
                {
                    Process p = Process.GetProcessById(proceso);
                    ProcessModule processModule = p.MainModule;
                    Console.WriteLine("Name: " + p.ProcessName + " Hora de Comienzo: " + p.StartTime + " ID: " + p.Id + " Titulo Ventana: " + p.MainWindowTitle + " Nombre Modulo: " + processModule.ModuleName + " Nombre del archivo: " + processModule.FileName);
                    verificar = true;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Numero de proceso incorrecto");
                    verificar = false;
                }
            } while (proceso < 0 || proceso > 65555 || !verificar);
        }
    }
}
