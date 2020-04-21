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
        static void Main(string[] args)
        {
            int op = 0;
            Videojuegos juegos;
            List<Videojuegos> almacen = new List<Videojuegos>();

#if DIRECTIVA
            almacen.Add(new Videojuegos("titulo 1", 2000, Videojuegos.Estilo.Estrategia, "Samsung"));
            almacen.Add(new Videojuegos("titulo 2", 2123, Videojuegos.Estilo.Deportivo, "CHUAN"));
            almacen.Add(new Videojuegos("titulo 3", 345, Videojuegos.Estilo.Videoaventuras, "TRRSS"));
#endif
            void visualizar()
            {
                for (int i = 0; i < almacen.Count; i++)
                {
                    int aux = i + 1;
                    Console.WriteLine("Posición: " + aux + "Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
                }
            }
            void visualizarFormateado()
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
                            int año, estilo;
                            Console.WriteLine("Introduzca un titulo");
                            titulo = Console.ReadLine();
                            Console.WriteLine("Introduzca el fabricante");
                            fabricante = Console.ReadLine();
                            do
                            {
                                Console.WriteLine("Introduzca el año");
                                año = Convert.ToInt32(Console.ReadLine());
                            } while (año < 1958 || año > 2020);
                            do
                            {
                                Console.WriteLine("Eliga la categoria 1-Arcade,2-Videoaventura,3-Shootemup,4-Estrategia,5-Deportivo");
                                estilo = Convert.ToInt32(Console.ReadLine());

                            } while (estilo > 5 || estilo < 1);
                            int siNo = 0;
                            do
                            {
                                Console.WriteLine("Si desea insertar el dato al principio pulse 1 en caso contrario pulse 2");
                                siNo = Convert.ToInt32(Console.ReadLine());
                            } while (siNo < 1 || siNo > 2);

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
                            Console.WriteLine("Que posicion desea borrar");
                            pos = Convert.ToInt32(Console.ReadLine());
                            almacen.RemoveAt(pos - 1);
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
                            int añoo, estiloo;
                            do
                            {
                                Console.WriteLine("Introduzca un año determinado");
                                añoo = Convert.ToInt32(Console.ReadLine());
                            } while (añoo < 1958 || añoo > 2020);
                            do
                            {
                                Console.WriteLine("Eliga la categoria 1-Arcade,2-Videoaventura,3-Shootemup,4-Estrategia,5-Deportivo");
                                estiloo = Convert.ToInt32(Console.ReadLine());
                            } while (estiloo > 5 || estiloo < 1);
                            for (int i = 0; i < almacen.Count; i++)
                            {
                                if (almacen[i].Año == añoo && almacen[i].Tipojuego == (Videojuegos.Estilo)estiloo)
                                {
                                    Console.WriteLine("Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
                                }
                            }
                            break;
                        case 6:
                            int nElegir = 0;
                            visualizar();
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
                                    int añoNew;
                                    do
                                    {
                                        Console.WriteLine("Inserte un año nuevo");
                                        añoNew = Convert.ToInt32(Console.ReadLine());
                                    } while (añoNew < 1958 || añoNew > 2020);

                                    string fabricanteNew;
                                    Console.WriteLine("Introduce nuevo fabricante");
                                    fabricanteNew = Console.ReadLine();
                                    int estiloNew;
                                    do
                                    {
                                        Console.WriteLine("Eliga la categoria 1-Arcade,2-Videoaventura,3-Shootemup,4-Estrategia,5-Deportivo");
                                        estiloNew = Convert.ToInt32(Console.ReadLine());
                                    } while (estiloNew > 5 || estiloNew < 1);

                                    int estiloNewDefinitivo = estiloNew - 1;
                                    almacen[i].Titulo = tituloNew;
                                    almacen[i].Año = añoNew;
                                    almacen[i].Tipojuego = (Videojuegos.Estilo)estiloNewDefinitivo;
                                    almacen[i].Fabricante = fabricanteNew;
                                }
                            }
                            break;
                        case 7:
                            int res = 0;
                            do
                            {
                                Console.WriteLine("Esta seguro que desea borrar todo 1-SI 2-NO");
                                res = Convert.ToInt32(Console.ReadLine());
                            } while (res < 1 || res > 2);

                            if (res == 1)
                            {
                                almacen = new List<Videojuegos>();
                                Console.WriteLine("Se ha borrado correctamente");
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

    }
}
