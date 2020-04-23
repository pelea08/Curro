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
            facebookAds,
            marketing,
            seo,
            sem
        }
        static void Main(string[] args)
        {
            string[] nombres = { "pedro", "jesus", "maria", "jose", "peter", "mariano", "pablo", "tesla", "fatema", "jesusito", "manolito", "santiago" };
            int op = 0;
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
                    if (notaGenerada < 6)
                    {
                        tabla[i, j] = 0;
                    }
                    else if (notaGenerada < 11)
                    {
                        tabla[i, j] = 1;
                    }
                    else if (notaGenerada < 16)
                    {
                        tabla[i, j] = 2;
                    }
                    else if (notaGenerada < 26)
                    {
                        tabla[i, j] = 3;
                    }
                    else if (notaGenerada < 41)
                    {
                        tabla[i, j] = 4;
                    }
                    else if (notaGenerada < 56)
                    {
                        tabla[i, j] = 5;
                    }
                    else if (notaGenerada < 71)
                    {
                        tabla[i, j] = 6;
                    }
                    else if (notaGenerada < 81)
                    {
                        tabla[i, j] = 7;
                    }
                    else if (notaGenerada < 91)
                    {
                        tabla[i, j] = 8;
                    }
                    else if (notaGenerada < 96)
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
                        Console.WriteLine("El resultado de la media global es ");
                        Console.WriteLine("{0:0.00}", res);
                        break;
                    case 2:
                        int notaAlumno = 0;
                        string nombreBuscar = "";
                        //pedirNombre(nombreBuscar);
                        Console.WriteLine("Introduzca el nombre que desea a buscar");
                        nombreBuscar = Console.ReadLine();

                        for (int ñ = 0; ñ < nombres.Length; ñ++)
                        {
                            for (int p = 0; p < tabla.GetLength(0); p++)
                            {
                                if (nombres[ñ] == nombreBuscar || nombres[ñ] == nombreBuscar.ToLower())
                                {
                                    notaAlumno += tabla[ñ, p];
                                }
                            }
                        }
                        if (notaAlumno != 0)
                        {
                            Console.WriteLine("La media es: " + notaAlumno / Enum.GetNames(typeof(asignauras)).Length);
                        }
                        else
                        {
                            Console.WriteLine("Ese alumno no existe");
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
                                if (asignaturaBuscar == valoresEnum[o] || asignaturaBuscar.ToLower() == valoresEnum[o])
                                {
                                    sumaTotalAsignaturas += tabla[o, s];
                                }
                            }
                        }
                        if (sumaTotalAsignaturas != 0)
                        {
                            Console.WriteLine("La media de la asignatura es " + sumaTotalAsignaturas / tabla.GetLength(1));
                        }
                        else
                        {
                            Console.WriteLine("Asignatura inexistente");
                        }
                        break;
                    case 4:
                        //notas de un alumno determinado
                        int indice = 0;
                        bool verificar = false;
                        string[] al = Enum.GetNames(typeof(asignauras));
                        string nombreBuscar1 = "";
                        Console.WriteLine("Introduzca el nombre que desea a buscar");
                        nombreBuscar1 = Console.ReadLine();
                        Console.WriteLine("\nNOTAS");
                        for (int ñ = 0; ñ < nombres.Length; ñ++)
                        {
                            for (int t = 0; t < tabla.GetLength(0); t++)
                            {
                                if (nombres[ñ] == nombreBuscar1 || nombres[ñ] == nombreBuscar1.ToLower())
                                {
                                    Console.WriteLine(al[indice] + " " + tabla[t, ñ]);
                                    indice++;
                                    verificar = true;
                                }
                            }
                        }
                        if (verificar == false)
                        {
                            Console.WriteLine("Ese alumno no existe");
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
                        const string FORMAT = "{0,-15}  {1,-15}  {2,-15} {3,-15} {4,-15}";
                        Console.WriteLine(string.Format(FORMAT, "Alumno", "FacebookAds", "Marketing", "SEO", "SEM"));
                        Console.WriteLine("------------------------------------------------------------------------");
                        for (int w = 0; w < tabla.GetLength(1); w++)
                        {
                            Console.WriteLine(string.Format(FORMAT, nombres[w], tabla[0, w], tabla[1, w], tabla[2, w], tabla[3, w]));
                        }
                        break;
                }
            } while (op != 7);
        }

    }
}
