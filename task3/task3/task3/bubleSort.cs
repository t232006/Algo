using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
//    Попробовать оптимизировать пузырьковую сортировку.Сравнить количество операций сравнения
//оптимизированной и не оптимизированной программы. Написать функции сортировки, которые
//возвращают количество операций.
    class bubleSort
    {
        void swap(ref byte a, ref byte b)
        {
            a = (byte)(a + b);
            b = (byte)(a - b);
            a = (byte)(a - b);
        }
        public byte[] bubbleSortS(byte[] mas)
        {
            for (int i = mas.Length-1; i > 0; i--)
                for (int j = mas.Length-1; j > 0; j--)
                    if (mas[j] < mas[j - 1]) swap(ref mas[j], ref mas[j - 1]);
            return mas;
        }
        public byte[] bubbleSortUp(byte[] mas)
        {
            for (int i = mas.Length - 1; i > 0; i--)
                for (int j = mas.Length - 1; j > mas.Length-i-1; j--)
                    if (mas[j] < mas[j - 1]) swap(ref mas[j], ref mas[j - 1]);
            return mas;
        }
        public byte[] Shaiker(byte[] mas)
        {
            int j; int k=0; 
            for (int i = 0; i < mas.Length; i++)
                if (i%2==0)
                    {
                        for (j = k; j < mas.Length-1-k; j++)
                            if (mas[j] > mas[j + 1]) swap(ref mas[j], ref mas[j + 1]);  
                        k++;
                    }
                else
                    {
                        for (j = mas.Length - 1-k; j > k-1; j--)
                            if (mas[j] < mas[j - 1]) swap(ref mas[j], ref mas[j - 1]);  
                    }

                        
            return mas;
        }
    }
}
