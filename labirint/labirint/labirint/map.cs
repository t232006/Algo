using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labirint
{
    class Tmap
    {
        public struct OneCell
        {
            public short X;
            public short Y;
            public short state;
            public bool wall;
            public char symbol;
        }
        internal byte rows;
        internal byte cols;
        internal OneCell[,] map;
       /* public Tmap(byte r, byte c)
        {
            
        }*/
        public void SaveMap(string filename)
        {
            TransferMap();
            filename = "map\\" + filename + ' ' + cols + 'X' + rows + ".txt";
            StreamWriter f = new StreamWriter(filename);
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < cols; i++)
                    f.Write(map[i, j].symbol);
                f.WriteLine();
            }
            f.Close();
        }
        
        public void printMap()
        {
            TransferMap();
            for (int j = 0; j < rows; j++)
            {
                for (int i = 0; i < cols; i++)
                {
                    if (map[i,j].symbol== '°')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(map[i, j].symbol);
                        Console.ResetColor();
                    } else
                    Console.Write(map[i, j].symbol);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        protected void InitMap()
        {
            map = new OneCell[cols, rows];
            for (short i = 0; i < cols; i++)
                for (short j = 0; j < rows; j++)
                {
                    map[i, j].X = i;
                    map[i, j].Y = j;
                    if ((i % 2 != 0) && (j % 2 != 0))
                    {
                        map[i, j].state = 0;
                        map[i, j].wall = false;
                    }
                    else
                    {
                        map[i, j].state = -1;
                        map[i, j].wall = true;
                    }
                }
        }
        protected void TransferMap()
        {
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    if (map[j, i].symbol==0) //if there is no symbols
                    if (map[j, i].state==-1) map[j, i].symbol = '█';
                    else
                        //if (map[j, i].state >= 0)
                        map[j, i].symbol = ' ';
                    /*else
                        map[j, i].symbol = '°';*/




        }
    }
    #region Creator
    class TCreator : Tmap
    {
        Random step = new Random();
        
        List<OneCell> candidat = new List<OneCell>();
        List<OneCell> getCand(OneCell current)
        {
            List<OneCell> tempcand = new List<OneCell>();
            /*r*/
            if (current.X < cols - 2 && map[current.X + 2, current.Y].state == 0) tempcand.Add(map[current.X + 2, current.Y]);
            /*l*/
            if (current.X > 2 && map[current.X - 2, current.Y].state == 0) tempcand.Add(map[current.X - 2, current.Y]);

            /*d*/
            if (current.Y < rows - 2 && map[current.X, current.Y + 2].state == 0) tempcand.Add(map[current.X, current.Y + 2]);
            /*u*/
            if (current.Y > 2 && map[current.X, current.Y - 2].state == 0) tempcand.Add(map[current.X, current.Y - 2]);
            return tempcand;
        }
        protected void DestroyWall(OneCell current, short counter)
        {
            OneCell cand;

            List<OneCell> tempcand = getCand(current);
            map[current.X, current.Y].state = counter++;
            while (tempcand.Count != 0)
            {
                cand = tempcand[step.Next(tempcand.Count)];
                tempcand.Remove(cand);
                if (map[cand.X, cand.Y].state == 0)
                {
                    if (current.X == cand.X)
                        if (current.Y > cand.Y) map[current.X, current.Y - 1].state = counter;
                        else
                            map[current.X, current.Y + 1].state = counter;
                    else
                                            if (current.X > cand.X) map[current.X - 1, current.Y].state = counter;
                    else
                        map[current.X + 1, current.Y].state = counter;
                    DestroyWall(cand, ++counter);
                }

            }
        }
        public TCreator(byte r, byte c, short X_, short Y_)//:base(r,c)
        {
            rows = r; cols = c;
            //OneCell[,] map = new OneCell[cols, rows];
            InitMap();
            //map[X_, Y_].state = 1;
            OneCell OC = map[X_, Y_];
            DestroyWall(OC, 1);
        }        
    }
    #endregion
}
