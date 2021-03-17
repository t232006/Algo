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
            Stack<Point> st = new Stack<Point>();
            st.Push(p); st.Push(p); st.Push(p); st.Push(p);
            map[p.X, p.Y].symbol = 'S';
            map[goal.X, goal.Y].symbol = 'F';
            while ((p != goal)&&(st.Count!=0))
            {
                    Point p1;
                if (map[p.X + 1, p.Y].state == 0)
                {
                    p1 = new Point(p.X + 1, p.Y);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                    //CreateTrack(st.Peek(),goal);

                }
                else
                if (map[p.X, p.Y + 1].state == 0)
                {
                    p1 = new Point(p.X, p.Y + 1);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                    //CreateTrack(st.Peek(), goal);
                }
                else
                if (map[p.X - 1, p.Y].state == 0)
                {
                    p1 = new Point(p.X - 1, p.Y);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                    //CreateTrack(st.Peek(), goal);
                }
                else
                if (map[p.X, p.Y - 1].state == 0)
                {
                    p1 = new Point(p.X, p.Y - 1);
                    st.Push(p1);
                    map[p1.X, p1.Y].state = ++map[p.X, p.Y].state;
                    //CreateTrack(st.Peek(), goal);
                }
                else p1 = st.Pop();
                    //else if (st.Count!=0) CreateTrack(st.Pop(), goal);
                p = p1;
                //Console.WriteLine(p);

                } 
            
        }

    }
}
