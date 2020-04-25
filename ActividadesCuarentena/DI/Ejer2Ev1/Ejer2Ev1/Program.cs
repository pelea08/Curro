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

            Colegio c = new Colegio();
            do
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("1-Media notas toda tabla");
                Console.WriteLine("2-Media de un alumno");
                Console.WriteLine("3-Media de una asignatura");
                Console.WriteLine("4-Visualizar notas de un alumno");
                Console.WriteLine("5-Nota máxima y mínima de un alumno");
                Console.WriteLine("6-Visualiza tabla completa");
                Console.WriteLine("7-Salir");
                try
                {
                    op = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduzca números");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Introduzca el rango adecuado");
                }
                switch (op)
                {
                    case 1:
                        Console.WriteLine("El resultado de la media global es ");
                        Console.WriteLine("{0:0.00}", c.calcularMediaTodos());
                        break;
                    case 2:
                        double resultado = c.mediaAlumno();
                        if (resultado > 0)
                        {
                            Console.WriteLine("La media es: " + resultado);
                        }
                        else
                        {
                            Console.WriteLine("Ese alumno no existe");
                        }
                        break;
                    case 3:
                        double sumaTotalAsignaturas = c.mediaAsignatura();

                        if (sumaTotalAsignaturas != 0)
                        {
                            Console.WriteLine("La media de la asignatura es " + sumaTotalAsignaturas);
                        }
                        else
                        {
                            Console.WriteLine("Asignatura inexistente");
                        }
                        break;
                    case 4:
                        c.visualizarNotasAlumno();
                        break;
                    case 5:
                        c.notaMaxMinAlumno();
                        break;
                    case 6:
                        c.tablaCompleta();
                        break;
                }
            } while (op != 7);
        }

    }
}
