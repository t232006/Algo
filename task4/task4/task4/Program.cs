using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            stepmap sm = new stepmap();
            sm.readmap("map.txt");
            //sm.printmap(sm.map);
            sm.fillgoal();
            sm.printmap(sm.goal);
            Console.ReadKey();
        }
    }
}
