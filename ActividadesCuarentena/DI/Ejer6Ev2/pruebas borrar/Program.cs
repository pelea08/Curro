using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebas_borrar
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "adasdasd";
            char[] ass = a.ToCharArray();
            for (int i = 0; i < ass.Length; i++)
            {
                Console.WriteLine("" + ass[i]);

            }


            Console.ReadLine();
        }
    }
}
