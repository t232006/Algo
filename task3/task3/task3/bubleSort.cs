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
        public byte[] bubbleSortS(byte[] mas1)
        {
            byte[] mas = mas1;
            for (int i = mas.Length-1; i > 0; i--)
                for (int j = mas.Length-1; j > 0; j--)
                    if (mas[j] < mas[j - 1]) swap(ref mas[j], ref mas[j - 1]);
            return mas;
        }
        public byte[] bubbleSortUp(byte[] mas1)
        {
            byte[] mas = mas1;
            for (int i = mas.Length - 1; i > 0; i--)
                for (int j = mas.Length - 1; j > mas.Length-i; j--)
                    if (mas[j] < mas[j - 1]) swap(ref mas[j], ref mas[j - 1]);
            return mas;
        }
        public byte[] Shaiker(byte[] mas1)
        {
            byte[] mas = mas1;
            for (int i = 0; i > mas.Length; i++)
                for (int j = 0; j > mas.Length; j++)
                    if (mas[j] > mas[j - 1]) swap(ref mas[j], ref mas[j - 1]);
            return mas;
        }
    }
}
