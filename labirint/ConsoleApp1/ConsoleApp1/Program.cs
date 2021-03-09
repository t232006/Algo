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
            Random r = new Random();
                int t; int tt=0;
            do
            {
                t = r.Next(2);
                Console.Write($"{t} ");
                tt++;
            }
            while (tt != 100);
            Console.ReadKey();

        }
    }
}
