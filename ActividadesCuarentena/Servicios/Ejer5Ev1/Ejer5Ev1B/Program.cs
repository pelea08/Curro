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

            Proceso opp = new Proceso(listaProcesos);
            Proceso opp1 = new Proceso(dlls);
            Proceso opp2 = new Proceso(cierreProceso);
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
                            opp(prioridad);
                            //                            Curro Profesor, [24.04.20 11:36]
                            //En el cada case del switch simplemente haces

                            //Curro Profesor, [24.04.20 11:36]
                            //delegado = funcionAEjecutar

                            //Curro Profesor, [24.04.20 11:36]
                            //y al final ejecutas el delegado

                            //Curro Profesor, [24.04.20 11:37]
                            //Si no lo ves bien repasa primero los ejercicios de delegados que hicimos a principio de curso que te pueden venir bien

                            //Curro Profesor, [24.04.20 11:37]
                            //El del menú y el de las operaciones


                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduce números");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Introduce un ´numero adecuado");
                        }
                        break;
                    case 2:
                        try
                        {
                            int pid;
                            Console.WriteLine("Introduce un pid");
                            pid = Convert.ToInt32(Console.ReadLine());
                            //dlls(pid);
                            opp1(pid);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduce números");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Introduce un ´numero adecuado");
                        }

                        break;
                    case 3:
                        try
                        {
                            int pid;
                            Console.WriteLine("Introduce un pid");
                            pid = Convert.ToInt32(Console.ReadLine());
                            //Process p = Process.GetProcessById(pid);
                            //p.Kill();
                            opp2(pid);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Introduce números");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Introduce un ´numero adecuado");
                        }
                        break;
                }
            } while (op != 4);
        }
        static void listaProcesos(int prioridad)
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
        static void dlls(int pid)
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
        }
        static void cierreProceso(int id)
        {
            Process p = Process.GetProcessById(id);
            p.CloseMainWindow();

        }
    }
}
