using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class Program
    {
        class Tmap
        {
            public struct OneCell
            {
                public short X;
                public short Y;
                public short state;
            }
            static byte rows = 7;
            static byte cols = 7;
            public OneCell[,] map = new OneCell[rows, cols];
            List<OneCell> candidat = new List<OneCell>();
            List<OneCell> getCand(OneCell current)
            {
                List<OneCell> tempcand = new List<OneCell>();
 /*r*/          if (current.X < cols - 2 && map[current.X + 2, current.Y].state == 0) tempcand.Add(map[current.X + 2, current.Y]);
 /*l*/          if (current.X > 2 && map[current.X - 2, current.Y].state == 0) tempcand.Add(map[current.X - 2, current.Y]);
              
 /*d*/          if (current.Y < rows - 2 && map[current.X, current.Y + 2].state == 0) tempcand.Add(map[current.X, current.Y + 2]);
 /*u*/          if (current.Y > 2 && map[current.X, current.Y - 2].state == 0) tempcand.Add(map[current.X, current.Y - 2]);
                return tempcand;
            }
            void DestroyWall (OneCell current, short counter)
            {
                OneCell cand;
                Random step = new Random();
                List<OneCell> tempcand = getCand(current);
                if (tempcand.Count != 0)
                {
                    cand = tempcand[step.Next(tempcand.Count)];
                    map[current.X,current.Y].state = counter++;
                    if (current.X == cand.X)
                        if (current.Y > cand.Y) map[current.X, current.Y - 1].state = counter; else 
                                                map[current.X, current.Y + 1].state = counter;
                    else
                        if (current.X > cand.X) map[current.X - 1, current.Y].state = counter; else
                                                map[current.X + 1, current.Y].state = counter;
                    DestroyWall(cand, ++counter);
                }  
            }
            public Tmap(short X_,short Y_)
            {
                InitMap();
                //map[X_, Y_].state = 1;
                OneCell OC=map[X_,Y_];
                DestroyWall(OC,1);
            }
            public void printMap()
            {
                for (int i=0; i<rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                        if (map[i, j].state == -1)
                            Console.Write('█');
                        else Console.Write(' ');
                    Console.WriteLine();
                }
                Console.ReadKey();
            }
            void InitMap()
            {
                for (short i = 0; i < rows; i++)
                for (short j = 0; j < cols; j++)
                    {
                        map[i, j].X = i; 
                        map[i, j].Y = j;
                        if ((i % 2 != 0) && (j % 2 != 0))
                            map[i, j].state = 0;
                        else map[i, j].state = -1;
                    }
            }
        }  
        static void Main(string[] args)
        {
            Tmap map1 = new Tmap(1,1);
            map1.printMap(); 
        }
    }
}
