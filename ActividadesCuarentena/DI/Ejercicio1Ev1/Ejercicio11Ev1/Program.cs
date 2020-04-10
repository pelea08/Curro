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
            Videojuegos juego1 = new Videojuegos("titulo 1", 2000, Videojuegos.Estilo.Estrategia, "Samsung");
            Videojuegos juego2 = new Videojuegos("titulo 2", 2123, Videojuegos.Estilo.Deportivo, "CHUAN");
            Videojuegos juego3 = new Videojuegos("titulo 3", 345, Videojuegos.Estilo.Videoaventuras, "TRRSS");
            List<Videojuegos> almacen = new List<Videojuegos>();
            almacen.Add(juego1);
            almacen.Add(juego2);
            almacen.Add(juego3);

            void visualizar()
            {
                for (int i = 0; i < almacen.Count; i++)
                {
                    int aux = i + 1;

                    Console.WriteLine("Posición: " + aux + "-" + "Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
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

                            //REVISAR LO DE PRINCIPIO Y FINAL DE LA COLECION DE INSERCION
                            String titulo, fabricante;
                            int año, estilo;
                            Console.WriteLine("Introduzca un titulo");
                            titulo = Console.ReadLine();
                            Console.WriteLine("Introduzca el fabricante");
                            fabricante = Console.ReadLine();
                            Console.WriteLine("Introduzca el año");
                            año = Convert.ToInt32(Console.ReadLine());
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
                            //Si existe que muestre sus datos
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
                            visualizar();
                            break;
                        case 5:
                            //Visualizar Videojuegos año determinado y estilo determinado
                            int añoo, estiloo;
                            Console.WriteLine("Introduzca un año determinado");
                            añoo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Eliga la categoria 1-Arcade,2-Videoaventura,3-Shootemup,4-Estrategia,5-Deportivo");
                            estiloo = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < almacen.Count; i++)
                            {
                                if (almacen[i].Año == añoo && almacen[i].Tipojuego == (Videojuegos.Estilo)estiloo)
                                {
                                    Console.WriteLine("Titulo: " + almacen[i].Titulo + " Estilo: " + almacen[i].Tipojuego + " Fabricante: " + almacen[i].Fabricante + " Año: " + almacen[i].Año);
                                }
                            }
                            break;
                        case 6:
                            //Modificación de un videojuego (buscará por posición)



                            int nElegir = 0;
                            visualizar();
                            Console.WriteLine("Introduzca el numero de posicion del juego que desea modificar");
                            nElegir = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < almacen.Count; i++)
                            {
                                //OJO REVISAR ESTA VAINA
                                int n = i + 1;
                                if (n == nElegir)
                                {
                                    String tituloNew;
                                    Console.WriteLine("Introduzca un nuevo titulo");
                                    tituloNew = Console.ReadLine();
                                    int añoNew;
                                    Console.WriteLine("Inserte un año nuevo");
                                    añoNew = Convert.ToInt32(Console.ReadLine());
                                    string fabricanteNew;
                                    Console.WriteLine("Introduce nuevo fabricante");
                                    fabricanteNew = Console.ReadLine();
                                    int estiloNew;
                                    Console.WriteLine("Eliga la categoria 1-Arcade,2-Videoaventura,3-Shootemup,4-Estrategia,5-Deportivo");
                                    estiloNew = Convert.ToInt32(Console.ReadLine());
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
                            Console.WriteLine("Esta seguro que desea borrar todo 1-SI 2-NO");
                            res = Convert.ToInt32(Console.ReadLine());
                            if (res == 1)
                            {
                                almacen = new List<Videojuegos>();

                            }


                            break;


                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Introduzca un valor valido");
                }

            } while (op != 8);

            Console.ReadLine();

        }

    }
}
