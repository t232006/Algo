using System;
using System.Collections.Generic;
using System.Drawing;
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
        public void CreateTrack(Point p, Point goal)
        {
            Point p_ = p; Point goal_ = goal;
            Stack<Point> st = new Stack<Point>();
            st.Push(p); st.Push(p); st.Push(p); st.Push(p);
            map[p.X, p.Y].symbol = 'S';
            map[goal.X, goal.Y].symbol = 'F';
            #region build_field
            while ((p != goal)&&(st.Count!=0))
            {
                    Point p1;
                if (map[p.X + 1, p.Y].state == 0)
                {
                    p1 = new Point(p.X + 1, p.Y);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                }
                else
                if (map[p.X, p.Y + 1].state == 0)
                {
                    p1 = new Point(p.X, p.Y + 1);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                }
                else
                if (map[p.X - 1, p.Y].state == 0)
                {
                    p1 = new Point(p.X - 1, p.Y);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                }
                else
                if (map[p.X, p.Y - 1].state == 0)
                {
                    p1 = new Point(p.X, p.Y - 1);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                }
                else p1 = st.Pop();
                p = p1;

                #endregion
            }
            short min = map[p.X, p.Y].state;
            goal = p_; p = goal_; //start becomes goal and bies versa
            while (p != goal)
            {
                //List<short> folk = new List<short>();
                short[] folk = new short[4]; byte fix=0;
                if (map[p.X + 1, p.Y].state > 0) folk[0] = map[p.X + 1, p.Y].state;
                if (map[p.X - 1, p.Y].state > 0) folk[1] = map[p.X - 1, p.Y].state;
                if (map[p.X, p.Y + 1].state > 0) folk[2] = map[p.X, p.Y + 1].state;
                if (map[p.X, p.Y - 1].state > 0) folk[3] = map[p.X, p.Y - 1].state;
                //fix = i;
                for (byte i = 0; i < folk.Length; i++) if ((folk[i] < min)&&(folk[i] > 0))
                    {
                        fix = i;
                        min = folk[i];
                    }
                switch (fix)
                {
                    case 0:
                        p = new Point(p.X + 1, p.Y);
                        break;
                    case 1:
                        p = new Point(p.X - 1, p.Y);
                        break;
                    case 2:
                        p = new Point(p.X, p.Y + 1);
                        break;
                    case 3:
                        p = new Point(p.X, p.Y - 1);
                        break;
                }
                map[p.X, p.Y].symbol = '°';
                //Console.WriteLine(p);
            }
            
        }

    }
}
