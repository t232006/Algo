using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    //Реализовать функцию перевода из десятичной системы в двоичную, 
    //    используя рекурсию.
    class toBin
    {
        public void f(int n)
        {
            int p=0;
            if (n < 2) p=n;
            else
            {
                p=(n % 2);
                f(n / 2);
            }
            Console.Write(p);

        }
    }
}
