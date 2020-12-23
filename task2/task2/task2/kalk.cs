using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    
    class calk
    {
        int[] mas;
        int begin; int end;
        public calk(int begin, int end) 
            {
                this.begin = begin; this.end = end;
            } 
        public int WithMas()
        {
            mas = new int[end+1]; int st;
            mas[begin] = 1; 
            mas[begin + 1] = 1;
            if (begin % 2 != 0) { mas[begin + 2] = 1; st = 3; } else st = 2;
            for (int i=begin+st; i<=end; i++)
            {
                mas[i] = mas[i - 1];
                if (i % 2 == 0)  mas[i]+= mas[i / 2]; 
            }
            return mas[end];
        }
        public int f(int n)
        {
            if ((n == begin) || (n == begin + 1) || (n == begin + 2) && (begin % 2 != 0)) return 1;
            else
            if (n % 2 == 0)
                return f(n / 2) + f(n - 1);
            else
                return f(n - 1);
        }
    }
}
