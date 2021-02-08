using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class toPostFix
    {
        StringBuilder origin;
        StringBuilder newstring=new StringBuilder("");
        List<char> symbols = new List<char>() {'~', '+', '-', '*', '/', '(', ')'};
        //List<char> symbols1 = new List<char>() { '~', '+', '-', '*', '/', '('};
        byte[,] progr = new byte[6, 7] {
            { 4, 1, 1, 1, 1, 1, 5 },
            { 2, 1, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 1, 2 },
            { 2, 2, 2, 2, 2, 1, 2 },
            { 5, 1, 1, 1, 1, 1, 3 }
        };

        Stack<char> Texas=new Stack<char>();
        public toPostFix(StringBuilder origin)
        {
            origin.Append('~');
            origin.Insert(0, '~');
            int i = 1;
            if (origin[i] == '-') origin.Insert(1, '0'); i++;
            while (i++ < origin.Length-1)
            {
                if (origin[i] == '-')
                    if (origin[i - 1] == '(')
                    {
                        origin.Insert(i, '0');
                        i += 2;
                    }
                    else
                    if (symbols.Contains(origin[i - 1]))
                    {
                        Console.WriteLine("Ошибка! Проверь свою запись!");
                        goto finish;
                    }

            }
            this.origin = origin;
            Console.WriteLine(this.origin);
            implementation();
        finish:;
        }
        void action0(byte i)
        {
            newstring.Append(origin[i]);
            origin.Remove(i,1);
        }
        void action1(byte i)
        {
            Texas.Push(origin[i]);
            origin.Remove(i, 1);
        }
        void action2()
        {
            newstring.Append(Texas.Pop());
        }
        void action3(byte i)
        {
            origin.Remove(i, 1);
            Texas.Pop();
        }
        void implementation()
        {
            byte k = 0;
            action1(0);
            while (k < origin.Length)
            {
                char cur = origin[k];
                if (!symbols.Contains(cur)) action0(k);
                else
                {
                    int a = symbols.IndexOf(Texas.Peek());
                    int b = symbols.IndexOf(cur);
                    switch (progr[a, b])
                    {
                        case 1:
                            action1(k);
                            break;
                        case 2:
                            action2();
                            break;
                        case 3:
                            action3(k);
                            break;
                        case 5:
                            Console.WriteLine("Ошибка! Проверь свою запись!");
                            k++;
                            break;
                        case 4:
                            Console.WriteLine(newstring);
                            k++;
                            break;
                    }
                        
                }
            }
        }
    }
}
