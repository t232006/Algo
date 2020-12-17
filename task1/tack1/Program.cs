using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tack1
{
    class Program
    {
        static void Main(string[] args)
        {
            ////==================task 14 about Automorph numbers==================
            //Console.Writeline("Введите предел")
            //int limit = int.Parse(Console.ReadLine());
            //for (uint i = 0; i < limit; i++)
            //{
            //    Automorph am = new Automorph(i);
            //    if (am.IsAutomorhp()) Console.WriteLine(i);
            //}
            //===================task 13 about random Generator====================
            //Console.WriteLine("Сколько случайных чисел вывести?");
            //int n = int.Parse(Console.ReadLine());
            //Generator gen = new Generator();
            //for (int i=1; i<=n; i++)
            //{
            //    Console.WriteLine(gen.Create());
            //}
            //===================task 11 about Average numbers=====================
            Average av = new Average();
            Console.WriteLine(av.Aver());

            
            Console.ReadLine();
        }
    }
}
