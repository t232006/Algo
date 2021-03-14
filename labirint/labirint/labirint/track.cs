using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class Ttrack:Tmap
    {
        public void LoadMap(string filename)
        {
            StreamReader f = new StreamReader(filename);
            byte i = 1; string s = f.ReadLine();
            do
            {
                i++;
                s = f.ReadLine();
            }
            while (!f.EndOfStream);
            rows = i; cols = (byte)s.Length;
            map = new OneCell[cols, rows];
            f = new StreamReader(filename);
            byte j = 0;
            do
            {
                s = f.ReadLine();
                for (i = 0; i < s.Length; i++)
                    if (s[i] == '█') map[i, j].state = -1;
                    else map[i, j].state = 0;
                j++;
            }
            while (!f.EndOfStream);
            f.Close();
        }
        public Ttrack(TCreator m)
        {
            map = m.map;
            rows = m.rows; cols = m.cols;
            for (int i=0; i<rows; i++)
                for (int j=0; j<cols; j++)
                {
                    if (map[j, i].state == -1) map[j, i].wall = true;
                    else
                    {
                        map[j, i].wall = false;
                        map[j, i].state = 0;
                    }
                }
        }
        public Ttrack(string filename)
        {
            LoadMap(filename);
        }

    }
}
