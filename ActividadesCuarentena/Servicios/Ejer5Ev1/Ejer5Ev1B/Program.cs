using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer5Ev1B
{
    class Program
    {
        public delegate void Proceso(int a);

        static void Main(string[] args)
        {
            int op = 0;
            Proceso[] opp = { new Proceso(listaProcesos), new Proceso(dlls), new Proceso(cierreProceso) };

            do
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("1-.Listado de procesos");
                Console.WriteLine("2-.DLLs de un proceso");
                Console.WriteLine("3-.Cierre de un proceso");
                Console.WriteLine("4.-Salir");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        try
                        {
                            int prioridad;
                            Console.WriteLine("Introduce una prioridad");
                            prioridad = Convert.ToInt32(Console.ReadLine());
                            opp[0].Invoke(prioridad);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduce números");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Introduce un número adecuado");
                        }
                        break;
                    case 2:
                        opp[1].Invoke(pidd());
                        break;
                    case 3:
                        opp[2].Invoke(pidd());
                        break;
                }
            } while (op != 4);
        }

        public static int pidd()
        {
            int pid = 0;

            try
            {
                Console.WriteLine("Introduce un pid");
                pid = Convert.ToInt32(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("Introduce números");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Introduce un ´numero adecuado");
            }
            return pid;

        }
        public static void listaProcesos(int prioridad)
        {
            Process[] p = Process.GetProcesses();
            foreach (Process process in p)
            {
                if (process.BasePriority <= prioridad)
                {
                    Console.WriteLine("PID: " + process.Id + " Nombre: " + process.ProcessName + " Prioridad: " + process.BasePriority);
                }
            }



        }
        public static void dlls(int pid)
        {
            try
            {
                Process pp = Process.GetProcessById(pid);
                ProcessModuleCollection pepe = pp.Modules;
                foreach (ProcessModule processModule in pepe)
                {
                    Console.WriteLine(processModule.ModuleName);
                }
            }
            catch (ArgumentException)
            {

            }
            catch (System.ComponentModel.Win32Exception)
            {
                Console.WriteLine("No puedes obtener esa informacion");
            }
        }
        public static void cierreProceso(int id)
        {
            int res = 0;
            Process p = Process.GetProcessById(id);

            try
            {
                Console.WriteLine("Desea cerrar el proceso 1-SI 2-NO");
                res = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Solo son validos es numero 1 o 2");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Solo son validos es numero 1 o 2");
            }
            
            if (res == 1)
            {
                p.Kill();
            }

        }
    }
}
