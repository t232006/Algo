using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            //toBin tb = new toBin();
            powers pow = new powers();
            //tb.f(59);
            //Console.WriteLine(pow.NotRec(3, 9));
            //Console.WriteLine(pow.Rec(3, 9));
            //Console.WriteLine(pow.EvenProp(3, 9));
            calk c = new calk(2, 10);
            Console.WriteLine(c.WithMas());
            Console.WriteLine(c.f(10));
            Console.ReadLine();
        }
    }
}
