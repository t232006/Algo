using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task4
{
    struct dimention {public byte m; public byte n; };
    class stepmap
    {
        public int[,] map;
        public int[,] goal; 
        dimention dim;
        
        public void readmap(string filename)
        {
            StreamReader f = new StreamReader(filename);
            string[] s;
            s=f.ReadLine().Split(' ');
            dim.m = Convert.ToByte(s[0]); dim.n = Convert.ToByte(s[1]);
            map = new int[dim.m, dim.n];
            goal = new int[dim.m, dim.n];
            string[] t = f.ReadToEnd().Split(' ','\n');
            for (int i = 0; i < dim.m; i++)
                for (int j = 0; j < dim.n; j++)
                    map[i,j] = Convert.ToByte(t[j + 4 * i]);
            f.Close();
        }
        public void printmap(int[,] mas)
        {
            for (int i = 0; i < dim.m; i++)
            {
                for (int j = 0; j < dim.n; j++)
                    Console.Write($"{mas[i, j]}, ");
                Console.WriteLine();
            }
        }
        int calcgoal(byte i, byte j)
        {
            if ((i == 0) || (j == 0)) return 1;
            else if (map[i, j] != 0)
                return (calcgoal((byte)(i - 1), j) + calcgoal(i, (byte)(j - 1)));
            else return 0;
        }
        public void fillgoal()
        {
            for (byte i = 0; i < dim.m; i++)
                for (byte j = 0; j < dim.n; j++)
                {
                    
                    goal[i, j] = calcgoal(i, j);
                }
        }

    }
}
