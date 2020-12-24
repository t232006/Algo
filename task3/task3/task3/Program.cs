using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    
    class Program
    {
        static byte[] mas; //= { 8, 3, 5, 1, 2, 4, 3, 8, 2, 6, 8, 9, 2, 6, 3, 7, 2, 6, 5, 7, 8, 9, 5, 8, 9, 8, 5 };
        //static byte[] MyMas = 
        
        delegate byte[] Func(byte[] mas);
        static void createMas(int dim)
        {
            mas = new byte[dim];
            Random rand = new Random();
            for (int i = 0; i < dim; i++) mas[i] = (byte)rand.Next(10);
        }
        static void ToString(byte[] mas)
        {
            foreach (byte i in mas)
                Console.Write($"{i}, ");
            Console.WriteLine();
        }

        static string TimeCounter(Func Sort)
        {
            DateTime dt =DateTime.Now;
            //ToString(mas);
            ToString(Sort((byte[])mas.Clone()));
            //ToString(mas);
            TimeSpan el = DateTime.Now - dt;
            return "Прошло миллисекунд: "+(el.TotalMilliseconds).ToString();
        }
        
        static void Main(string[] args)
        {
            createMas(15);
            bubleSort bs = new bubleSort();

            ToString(mas);
            Console.WriteLine(TimeCounter(bs.bubbleSortS));
            Console.WriteLine(TimeCounter(bs.bubbleSortUp));
            Console.WriteLine(TimeCounter(bs.Shaiker));

            //ToString(bs.bubbleSortS(mas));
            //ToString(bs.bubbleSortUp(mas));
            Console.ReadLine();

        }
    }
}
