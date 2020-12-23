using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    //Реализовать функцию возведения числа a в степень b:
    class powers
    {
        public ulong NotRec(ulong n, byte power)
        {
            ulong result = 1;
            if (power == 0) return 1; else
            {
                for (byte i = 1; i <= power; i++)
                    result *= n;
            }
            return result;  
        }
        public ulong Rec(ulong n, byte power)
        {
            ulong result = 1;
            if (power == 0) return 1;
            else
                result=Rec(n, (byte)(power - 1));
            return n*result;
        }
        public ulong EvenProp(ulong n, byte power)
        {
            ulong result = 0;
            if (power == 0) return 1;
            else
            if (power % 2 == 0)
            {
                result = EvenProp(n, (byte)(power / 2));
                return result *= result;
            }
            else
            {
                result= EvenProp(n, (byte)(power -1));
                return result * n;
            }
        }
    }
}
