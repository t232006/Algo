using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    
    class Program
    {
        static byte[] MyMas = { 8, 3, 5, 1, 2, 4, 3, 8, 2, 6, 8, 9, 2, 6, 3, 7, 2, 6, 5, 7, 8, 9, 5, 8, 9, 8, 5 };

        delegate byte[] Func(byte[] mas);
        static void ToString(byte[] mas)
        {
            foreach (byte i in mas)
                Console.Write($"{i}, ");
            Console.WriteLine();
        }

        static string TimeCounter(Func Sort)
        {
            DateTime dt =DateTime.Now;
            ToString(MyMas);
            ToString(Sort(MyMas));
            ToString(MyMas);
            return "Прошло миллисекунд: "+(DateTime.Now.Millisecond - dt.Millisecond).ToString();
        }
        
        static void Main(string[] args)
        {
            bubleSort bs = new bubleSort();
            
            Console.WriteLine(TimeCounter(bs.bubbleSortS));
            //Console.WriteLine(TimeCounter(bs.bubbleSortUp));
            //Console.WriteLine(TimeCounter(bs.Shaiker));

            //ToString(bs.bubbleSortS(mas));
            //ToString(bs.bubbleSortUp(mas));
            Console.ReadLine();

        }
    }
}
