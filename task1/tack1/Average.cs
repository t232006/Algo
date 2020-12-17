using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tack1
{
    //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать среднее 
    //арифметическое всех положительных четных чисел, оканчивающихся на 8.
    class Average
    {
        byte i = 0;
        int sum = 0;
        public double Aver()
        {
            double ret=0;
            int n = int.Parse(Console.ReadLine());
            if (n != 0)
                Aver();
            if ((n > 0) && (n % 10 == 8))
            {
                sum += n;
                i++;
            }
            if (i!=0) ret= sum / i;
            return ret;

            
        }
    }
}
