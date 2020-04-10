using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio11Ev1
{
    class Videojuegos
    {
        public string Titulo { set; get; }
        public int Año { set; get; }
        public Estilo Tipojuego { set; get; }
        public enum Estilo
        {

            Arcade,
            Videoaventuras,
            Shootemup,
            Estrategia,
            Deportivo
        }
        public string Fabricante { set; get; }

        public Videojuegos(string titulo, int año, Estilo tipojuego, string fabricante)
        {
            this.Titulo = titulo;
            this.Año = año;
            this.Tipojuego = tipojuego;
            this.Fabricante = fabricante;
        }
    }
}
