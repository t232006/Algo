using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    
    class calk
    {
        byte[] mas;
        int begin; int end;
        int dim;
        public calk(int begin, int end)
        {
            this.begin = begin; this.end = end;
            dim = end-begin;
            mas = new byte[dim];
        }
        public void razm(int k)
        {
            if (k == 0) make(); else
            for (byte i=1; i<=2; i++)
            {
                    mas[k-1] = i;
                    razm(k - 1);
            }
        }
        void printmas(int lim)
        {
            for (int i=0; i<lim; i++)
            Console.Write(mas[i]+" ");
            Console.WriteLine();
        }
        void make()
        {
            int n = begin; int i;
            for(i = 0; i < mas.Length; i++)
            {
                if (mas[i] == 1) n += 1; else n *= 2;
                if (n >= end) break;
            }
            if (n == end) printmas(i+1);
        }

    }
}
