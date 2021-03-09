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
            static byte rows = 19;
            static byte cols = 49;
            public OneCell[,] map = new OneCell[rows, cols];
            List<OneCell> candidat = new List<OneCell>();
            List<OneCell> getCand(OneCell current)
            {
                List<OneCell> tempcand = new List<OneCell>();
                if (current.X < cols - 1 && map[current.X + 2, current.Y].state == 0) tempcand.Add(map[current.X + 2, current.Y]);
                if (current.X > 2 && map[current.X - 2, current.Y].state == 0) tempcand.Add(map[current.X - 2, current.Y]);
                
                if (current.Y < rows - 1 && map[current.Y, current.Y + 2].state == 0) tempcand.Add(map[current.X, current.Y + 2]);
                if (current.X > 2 && map[current.Y, current.Y - 2].state == 0) tempcand.Add(map[current.Y, current.Y - 2]);
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
                    if (current.X == cand.X)
                        if (current.Y > cand.Y)
                        {
                            map[current.X, current.Y - 1].state = counter;
                            //DestroyWall(map[current.X, current.Y - 1], counter++);
                        }
                        else
                        {
                            map[current.X, current.Y + 1].state = counter;
                            //DestroyWall(map[current.X, current.Y + 1], counter++);
                        }

                    else
                        if (current.X > cand.X) 
                        { 
                            map[current.X - 1, current.Y].state = counter;
                            //DestroyWall(map[current.X - 1, current.Y], counter++);
                        }
                        else 
                        {
                            map[current.X + 1, current.Y].state = counter;
                            //DestroyWall(map[current.X + 1, current.Y], counter++);
                        }
                    DestroyWall(cand, counter++);
                }  
            }
            public Tmap(short X_,short Y_)
            {
                OneCell OC;
                OC.X = X_; OC.Y = Y_; OC.state = 0;
                InitMap();
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
