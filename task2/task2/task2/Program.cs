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
            calk cal = new calk(3, 10);
            cal.razm(10 - 3);
            Console.ReadLine();
        }
    }
}
