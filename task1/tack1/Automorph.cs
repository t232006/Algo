using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tack1
{
    /* Автоморфные числа.Натуральное число называется автоморфным, если оно равно 
     * последним цифрам своего квадрата.Например, 252 = 625. Напишите программу, которая 
     * вводит натуральное число N и выводит на экран все автоморфные числа, не превосходящие N.*/
    class Automorph
    {
        public ulong Num { get; }   //applicant
        byte[] NumArr;              //applicant in array reverce
        byte[] sqNumArr;            //applicant in square   
        ulong sqNum;
        public Automorph(ulong Num)
        {
            this.Num = Num;
            NumArr = NumToArr(Num);
            sqNum = Num * Num;
            sqNumArr = NumToArr(sqNum);
        }
        byte Capacity(ulong n)      //digit capacity n
        {
            ulong tempNum = n;
            byte i = (byte)0;
            while (tempNum>0)
            {
                tempNum /= 10;
                i++;
            }
            return i;
        }   
        byte[] NumToArr(ulong n)
        {
            ulong tempNum = n;
            byte[] tempArr = new byte[Capacity(n)];
            byte i = (byte)0;
            while (tempNum > 0)
            {
                tempArr[i++] = (byte)(tempNum % 10);
                tempNum /= 10;
            }
            return tempArr;
        }
        public bool IsAutomorhp()
        {
            for(int i=0; i<NumArr.Length; i++)
            {
                if (NumArr[i] != sqNumArr[i]) return false;
            }
            return true;
        }

    }
}
