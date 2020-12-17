using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tack1
{
    //Написать функцию, генерирующую случайное число от 1 до 100.
    class Generator
    {
        byte m= 101;
        byte a = 19;
        int xn;
        public Generator()
        {
            DateTime t = DateTime.Now;
            xn = t.Year + t.Month + t.Day + t.Minute + t.Second + t.Millisecond;
        }
        public Generator(int xn)
        {
            this.xn = xn;
        }
        public int Create()
        {
            xn= (byte)((a * xn) % m);
            return xn;
        }
    }
}
