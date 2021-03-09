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
                if (current.X < cols - 1 && map[current.X + 2, current.Y].state == -1) tempcand.Add(map[current.X + 2, current.Y]);
                if (current.X > 2 && map[current.X - 2, current.Y].state == -1) tempcand.Add(map[current.X - 2, current.Y]);
                
                if (current.Y < rows - 1 && map[current.Y, current.Y + 2].state == -1) tempcand.Add(map[current.X, current.Y + 2]);
                if (current.X < 2 && map[current.Y, current.Y - 2].state == -1) tempcand.Add(map[current.Y, current.Y - 2]);
                return tempcand;
            }
            void DestroyWall (OneCell current)
            {
                OneCell cand;
                Random step = new Random();
                cand = getCand(current)[step.Next(4)];
                if (current.X == cand.X)
                    if (current.Y > cand.Y) map[current.X, current.Y - 1].state = 0; else
                                            map[current.X, current.Y + 1].state = 0;
                else
                    if (current.X > cand.X) map[current.X - 1, current.Y].state = 0;
                                            map[current.X + 1, current.Y].state = 0;

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
            public void InitMap()
            {
                for (short i = 0; i < cells; i++)
                for (short j = 0; j < columns; j++)
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
            Tmap map1 = new Tmap();
            map1.InitMap(); map1.printMap(); 
        }
    }
}
