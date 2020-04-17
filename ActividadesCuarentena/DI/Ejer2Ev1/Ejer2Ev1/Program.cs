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
            string[] nombres = { "Pedro", "Jesus", "Maria", "Jose", "Peter", "Mariano", "Pablo", "Tesla", "Fatema", "Jesusito", "Manolito", "Santiago" };
            int op;
            Random r = new Random();
            //4 asignaturas 12 alumnos
            int[,] tabla = new int[4, 12];
            int i = 0;
            int j = 0;
            for (i = 0; i < tabla.GetLength(0); i++)
            {
                for (j = 0; j < tabla.GetLength(1); j++)
                {
                    int notaGenerada = r.Next(0, 101);
                    if (notaGenerada < 9)
                    {
                        tabla[i, j] = 0;
                    }
                    else if (notaGenerada < 19)
                    {
                        tabla[i, j] = 1;
                    }
                    else if (notaGenerada < 29)
                    {
                        tabla[i, j] = 2;
                    }
                    else if (notaGenerada < 39)
                    {
                        tabla[i, j] = 3;
                    }
                    else if (notaGenerada < 49)
                    {
                        tabla[i, j] = 4;
                    }
                    else if (notaGenerada < 59)
                    {
                        tabla[i, j] = 5;
                    }
                    else if (notaGenerada < 69)
                    {
                        tabla[i, j] = 6;
                    }
                    else if (notaGenerada < 79)
                    {
                        tabla[i, j] = 7;
                    }
                    else if (notaGenerada < 89)
                    {
                        tabla[i, j] = 8;
                    }
                    else if (notaGenerada < 99)
                    {
                        tabla[i, j] = 9;
                    }
                    else
                    {
                        tabla[i, j] = 10;
                    }
                }

            }



            do
            {
                Console.WriteLine("-----------------------");
                Console.WriteLine("1-Media Notas Toda Tabla");
                Console.WriteLine("2-Media de un alumno");
                Console.WriteLine("3-Media de una asignatura");
                Console.WriteLine("4-Visualizar notas de un alumno");
                Console.WriteLine("5-Nota máxima y mínima de un alumno");
                Console.WriteLine("6-Visualiza tabla completa");
                Console.WriteLine("7-Salir");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        int suma = 0;
                        int res ;
                        for (int k = 0; k < tabla.GetLength(0); k++)
                        {
                            for (int l = 0; l < tabla.GetLength(1); l++)
                            {
                                suma += tabla[i, j];
                            }
                        }
                        res = suma / 48;
                        Console.WriteLine("El resultado de la media es de :" + res);
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;



                }
            } while (op != 7);


        }
    }
}
