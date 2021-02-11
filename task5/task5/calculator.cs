using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class calculator: general
    {
        Stack<Double> calc = new Stack<Double>();
        public calculator(StringBuilder origin)
        {
            this.origin = origin;
        }
        public Double parser()
        {
            while (origin.Length > 0)
            {
                string s = "";
                if (digits.Contains(origin[0])) //if regular symbol is digit
                {
                    while (origin[0] != '&')
                    {
                        s += origin[0];
                        origin.Remove(0, 1);
                    }
                    origin.Remove(0, 1);
                    calc.Push(Double.Parse(s));
                }
                else
                {
                    Double a = calc.Pop();
                    Double b = calc.Pop();
                    switch (origin[0])
                    {
                        case '-':
                            calc.Push(b - a);
                            break;
                        case '+':
                            calc.Push(b + a);
                            break;
                        case '*':
                            calc.Push(b * a);
                            break;
                        case '/':
                            if (a != 0)
                                calc.Push(b / a);
                            else
                                Console.WriteLine("Деление на ноль!");
                            break;
                    }
                    origin.Remove(0, 1);
                }   
            }
            return calc.Pop();
            

            
            
                
        }


    }
}
