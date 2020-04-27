using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ignorar
{
    class Program
    {
        static readonly object l = new object();
        static void Main(string[] args)
        {
            int cont = 0;

            //while (cont % 1 == 0)
            //{
            //    lock (l)
            //    {
            //        Console.WriteLine("pepe");

            //    }
            //    Thread.Sleep(3000);
            //    cont++;





            //}
            Random r = new Random();
            int a = r.Next(2);
            Console.WriteLine(""+a);
            Console.ReadLine();
        }
    }
}
