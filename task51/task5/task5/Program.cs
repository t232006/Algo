using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder s=new StringBuilder(Console.ReadLine());
            toPostFix tpf = new toPostFix(s);
            Console.ReadLine();
        }
    }
}
