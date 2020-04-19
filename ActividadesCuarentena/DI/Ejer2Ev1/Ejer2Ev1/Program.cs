using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer2Ev1
{
    class Program
    {
        public enum asignauras
        {
            facebookads,
            marketing,
            seo,
            sem
        }
        static void Main(string[] args)
        {
            string[] nombres = { "Pedro", "Jesus", "Maria", "Jose", "Peter", "Mariano", "Pablo", "Tesla", "Fatema", "Jesusito", "Manolito", "Santiago" };
            int op;
            Random r = new Random();
            //4 asignaturas 12 alumnos
            int[,] tabla = new int[4, 12];
            int i;
            int j;
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
                    //Vigilar Excepciones00000000000000000000000000000000000000000000000000
                    case 1:
                        double suma = 0;
                        double res;
                        for (int k = 0; k < tabla.GetLength(0); k++)
                        {
                            for (int l = 0; l < tabla.GetLength(1); l++)
                            {
                                suma += tabla[k, l];
                            }
                        }
                        res = suma / tabla.Length;
                        //res = suma / (12*4);
                        Console.WriteLine("El resultado de la media es de :" + res);
                        break;
                    case 2:
                        int notaAlumno = 0;
                        string nombreBuscar;
                        Console.WriteLine("Introduzca el nombre que desea a buscar");
                        nombreBuscar = Console.ReadLine();
                        for (int ñ = 0; ñ < nombres.Length; ñ++)
                        {
                            for (int p = 0; p < tabla.GetLength(0); p++)
                            {
                                if (nombres[ñ] == nombreBuscar)
                                {

                                    notaAlumno += tabla[ñ, p];

                                }
                            }
                        }
                        //Console.WriteLine("RES: " + notaAlumno/4);
                        if (notaAlumno != 0)
                        {
                            Console.WriteLine("RES: " + notaAlumno / Enum.GetNames(typeof(asignauras)).Length);
                        }
                        else
                        {
                            Console.WriteLine("Introduzca el nombre adecuado");
                        }
                        break;
                    case 3:
                        int sumaTotalAsignaturas = 0;
                        string asignaturaBuscar;
                        Console.WriteLine("Introduzca una asignatura a buscar");
                        asignaturaBuscar = Console.ReadLine();
                        string[] valoresEnum = Enum.GetNames(typeof(asignauras));
                        for (int o = 0; o < valoresEnum.Length; o++)
                        {
                            for (int s = 0; s < tabla.GetLength(1); s++)
                            {
                                if (asignaturaBuscar == valoresEnum[o])
                                {
                                    sumaTotalAsignaturas += tabla[o, s];
                                }
                            }
                        }
                        if (sumaTotalAsignaturas != 0)
                        {
                            Console.WriteLine("La media de la asignatura es " + sumaTotalAsignaturas / tabla.GetLength(0));
                        }
                        else
                        {
                            Console.WriteLine("Intrduzca una asignatura valida");
                        }

                        break;
                    case 4:
                        //notas de un alumno determinado
                        bool verificar = false;
                        string nombreBuscar1;
                        Console.WriteLine("Introduzca el nombre que desea a buscar");
                        nombreBuscar1 = Console.ReadLine();
                        Console.WriteLine("\nNOTAS");

                        for (int ñ = 0; ñ < nombres.Length; ñ++)
                        {
                            for (int t = 0; t < tabla.GetLength(0); t++)
                            {
                                if (nombres[ñ] == nombreBuscar1)
                                {
                                    Console.WriteLine(tabla[t, ñ]);
                                    verificar = true;
                                }
                            }

                        }
                        if (verificar == false)
                        {
                            Console.WriteLine("Introduzca un nombre correcto");
                        }
                        break;
                    case 5:
                        int nMax = 0;
                        int nMin = 10;
                        bool verificar1 = false;
                        string nombreBuscar2 = "";
                        Console.WriteLine("Introduzca el nombre que desea a buscar");
                        nombreBuscar2 = Console.ReadLine();
                        Console.WriteLine("\nNOTAS");

                        for (int ñ = 0; ñ < nombres.Length; ñ++)
                        {
                            for (int t = 0; t < tabla.GetLength(0); t++)
                            {
                                if (nombres[ñ] == nombreBuscar2)
                                {
                                    int n = tabla[t, ñ];
                                    if (nMax < n)
                                    {
                                        nMax = n;
                                        verificar1 = true;
                                    }
                                    else if (nMin > n)
                                    {
                                        nMin = n;
                                    }
                                    //else if(nMin>n)
                                }
                            }

                        }
                        if (verificar1 == false)
                        {
                            Console.WriteLine("Introduzca un nombre correcto");
                        }
                        else
                        {
                            Console.WriteLine("La nota máxima de " + nombreBuscar2 + " es un " + nMax + " y la mínima un " + nMin);
                        }
                        break;
                    case 6:
                        for (int v = 0; v < tabla.GetLength(0); v++)
                        {
                            for (int w = 0; w < tabla.GetLength(1); w++)
                            {
                                Console.WriteLine(tabla[v, w]);
                            }
                        }
                        break;
                    case 7:

                        break;



                }
            } while (op != 7);


        }
    }
}
