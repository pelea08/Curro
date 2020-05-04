using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer4Ev2
{
    class Program
    {

        static void Main(string[] args)
        {
            ServidorArchivos servidorArchivos = new ServidorArchivos();
            //Console.WriteLine(servidorArchivos.leeArchivo("aa.txt", 300000));
            //Console.WriteLine(servidorArchivos.leePuerto());
            //servidorArchivos.guardaPuerto(2222);
            //Console.WriteLine(servidorArchivos.listaArchivos());
            servidorArchivos.iniciarServidorArchivos();
            Console.ReadLine();
        }
    }
}
