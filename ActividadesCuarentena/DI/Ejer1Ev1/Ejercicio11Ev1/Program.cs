#define DIRECTIVA
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11Ev1
{
    class Program
    {
        static List<Videojuegos> almacen = new List<Videojuegos>();
        static void Main(string[] args)
        {
            int op = 0;
            Videojuegos juegos;
#if DIRECTIVA
            almacen.Add(new Videojuegos("titulo 1", 2000, Videojuegos.Estilo.Estrategia, "Samsung"));
            almacen.Add(new Videojuegos("titulo 2", 2020, Videojuegos.Estilo.Deportivo, "CHUAN"));
            almacen.Add(new Videojuegos("titulo 3", 1958, Videojuegos.Estilo.Videoaventuras, "TRRSS"));
#endif
            do
            {
                Console.WriteLine("---------------------");
                Console.WriteLine("1-Insertar Nuevo Vieojuego");
                Console.WriteLine("2-Eliminar Vieojuego");
                Console.WriteLine("3-Comprobar Existencia Videojuego");
                Console.WriteLine("4-Visualizar Todos Los Vieojuegos");
                Console.WriteLine("5-Visualizar Videojuegos año determinado y estilo determinado");
                Console.WriteLine("6-Modificación Videojuego");
                Console.WriteLine("7-Borrar Todos");
                Console.WriteLine("8-Salir");
                Console.WriteLine("Selecione Una Opcion");
                try
                {
                    op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            String titulo, fabricante;
                            int año = 0;
                            int estilo = 0;
                            Console.WriteLine("Introduzca un titulo");
                            titulo = Console.ReadLine();
                            Console.WriteLine("Introduzca el fabricante");
                            fabricante = Console.ReadLine();
                            funcionAño(año);
                            funcionEstilo(estilo);
                            int siNo = 0;
                            bool banderaIntroducir = false;
                            do
                            {
                                try
                                {
                                    Console.WriteLine("Si desea insertar el dato al principio pulse 1 en caso contrario pulse 2");
                                    siNo = Convert.ToInt32(Console.ReadLine());
                                    banderaIntroducir = true;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Introduzca los numeros adecuados");
                                    banderaIntroducir = false;
                                }
                                catch (OverflowException)
                                {
                                    Console.WriteLine("Introduzca los numeros adecuados");
                                    banderaIntroducir = false;
                                }

                            } while (siNo < 1 || siNo > 2 || !banderaIntroducir);

                            juegos = new Videojuegos(titulo, año, (Videojuegos.Estilo)estilo - 1, fabricante);

                            if (siNo == 2)
                            {
                                almacen.Add(juegos);
                            }
                            else
                            {
                                almacen.Insert(0, juegos);
                            }
                            break;
                        case 2:
                            visualizar();
                            int pos = 0;
                            if (almacen.Count > 0)
                            {
                                Console.WriteLine("Que posicion desea borrar");
                                pos = Convert.ToInt32(Console.ReadLine());
                                try
                                {
                                    almacen.RemoveAt(pos - 1);
                                }
                                catch (ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("Introduzca un valor adecuado");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No puedes borrar nada,la lista esta vacia");
                            }
                            break;
                        case 3:
                            bool noExiste = true;
                            String tituloBuscar = "";
                            Console.WriteLine("Introduzca el titulo a buscar");
                            tituloBuscar = Console.ReadLine();
                            for (int i = 0; i < almacen.Count; i++)
                            {
                                if (almacen[i].Titulo == tituloBuscar)
                                {
                                    Console.WriteLine("ENHORABUENA HEMOS ENCONTRADO LO QUE BUSCAS \n");
                                    Console.WriteLine("Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
                                    noExiste = false;
                                }
                            }
                            if (noExiste)
                            {
                                Console.WriteLine("No se ha encontrado lo que busca");
                            }
                            break;
                        case 4:
                            visualizarFormateado();
                            break;
                        case 5:
                            bool sinResultados = false;
                            int añoo = 0;
                            int estiloo = 0;
                            funcionAño(añoo);
                            funcionEstilo(estiloo);

                            for (int i = 0; i < almacen.Count; i++)
                            {
                                if (almacen[i].Año == añoo && almacen[i].Tipojuego == (Videojuegos.Estilo)estiloo - 1)
                                {
                                    sinResultados = true;
                                    Console.WriteLine("Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
                                }
                            }
                            if (!sinResultados)
                            {
                                Console.WriteLine("No se a econtrado nada con esa busqueda");
                            }
                            break;
                        case 6:
                            int nElegir = 0;
                            visualizar();
                            if (almacen.Count > 0)
                            {
                                do
                                {
                                    Console.WriteLine("Introduzca el numero de posicion del juego que desea modificar");
                                    nElegir = Convert.ToInt32(Console.ReadLine());
                                } while (nElegir < 1 || nElegir > almacen.Count);
                                for (int i = 0; i < almacen.Count; i++)
                                {
                                    int n = i + 1;
                                    if (n == nElegir)
                                    {
                                        String tituloNew;
                                        Console.WriteLine("Introduzca un nuevo titulo");
                                        tituloNew = Console.ReadLine();
                                        int añoNew = 0;
                                        funcionAño(añoNew);

                                        string fabricanteNew;
                                        Console.WriteLine("Introduce nuevo fabricante");
                                        fabricanteNew = Console.ReadLine();
                                        int estiloNew = 0;

                                        funcionEstilo(estiloNew);

                                        int estiloNewDefinitivo = estiloNew - 1;
                                        almacen[i].Titulo = tituloNew;
                                        almacen[i].Año = añoNew;
                                        almacen[i].Tipojuego = (Videojuegos.Estilo)estiloNewDefinitivo;
                                        almacen[i].Fabricante = fabricanteNew;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("No hay videojuegos disponibles");
                            }
                            break;
                        case 7:
                            bool sino = false;
                            int res = 0;
                            if (almacen.Count > 0)
                            {
                                do
                                {
                                    try
                                    {
                                        Console.WriteLine("Esta seguro que desea borrar todo 1-SI 2-NO");
                                        res = Convert.ToInt32(Console.ReadLine());
                                        sino = true;
                                    }
                                    catch (FormatException)
                                    {
                                        sino = false;
                                    }
                                    catch (OverflowException)
                                    {
                                        sino = false;
                                    }

                                } while (res < 1 || res > 2 || !sino);

                                if (res == 1)
                                {
                                    almacen = new List<Videojuegos>();
                                    Console.WriteLine("Se ha borrado correctamente");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Colección de videojuegos vacia");
                            }
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduzca un valor valido");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Introduzca una opcion valida");
                }
            } while (op != 8);

            Console.ReadLine();

        }
        public static void visualizar()
        {
            for (int i = 0; i < almacen.Count; i++)
            {
                int aux = i + 1;
                Console.WriteLine("Posición: " + aux + " Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
            }
        }
        public static void visualizarFormateado()
        {
            const string FORMAT = "{0,-15}  {1,-15}  {2,-15}  {3,-15} {4,-15}";
            Console.WriteLine(string.Format(FORMAT, "Posición", "Titulo", "Tipo", "Fabricante", "Año"));
            for (int i = 0; i < almacen.Count; i++)
            {
                int aux = i + 1;
                Console.WriteLine(string.Format(FORMAT, aux, almacen[i].Titulo, almacen[i].Tipojuego, almacen[i].Fabricante, almacen[i].Año));
                if (aux % 10 == 0)
                {
                    Console.WriteLine("Pulse para continuar");
                    Console.ReadLine();
                }
            }
        }
        public static void funcionAño(int varAño)
        {
            bool evitarRepeticion = true;
            bool banderaAño = false;
            do
            {
                try
                {
                    Console.WriteLine("Introduzca el año");
                    varAño = Convert.ToInt32(Console.ReadLine());
                    banderaAño = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduce un año entre el 1958 y el 2020");
                    banderaAño = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Introduce un año entre el 1958 y el 2020");
                    banderaAño = true;
                    evitarRepeticion = true;
                }
                if (!evitarRepeticion)
                {
                    if (varAño < 1958 || varAño > 2020)
                    {
                        Console.WriteLine("El año  tiene que ser entre el 1958 y el 2020");
                    }
                }
            } while (varAño < 1958 || varAño > 2020 || banderaAño);


        }
        public static void funcionEstilo(int estiloo)
        {
            bool banderaEstilo2;
            do
            {
                try
                {
                    Console.WriteLine("Eliga la categoria 1-Arcade,2-Videoaventura,3-Shootemup,4-Estrategia,5-Deportivo");
                    estiloo = Convert.ToInt32(Console.ReadLine());
                    banderaEstilo2 = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduzca los numeros adecuados");
                    banderaEstilo2 = false;
                }
            } while (estiloo > 5 || estiloo < 1 || !banderaEstilo2);
        }
    }
}
