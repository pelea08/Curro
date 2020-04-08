using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //% HOMEPATH %
                Console.WriteLine(Environment.GetEnvironmentVariable("homepath")+"\\"+"Desktop" + "Desktop"+"\\" + "getword.txt");
                Console.ReadLine();
        }
    }
}
