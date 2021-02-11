using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    class general
    {
        protected List<char> symbols = new List<char>() { '~', '+', '-', '*', '/', '^', '(', ')' };
        protected List<char> digits = new List<char>() { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ',' };
        protected StringBuilder origin;
    }
    class toPostFix :general
    {
        public StringBuilder newstring=new StringBuilder("");
        //List<char> symbols1 = new List<char>() { '~', '+', '-', '*', '/', '('};
        byte[,] progr = new byte[7, 8] {
            { 4, 1, 1, 1, 1, 1, 1, 5 },
            { 2, 1, 1, 1, 1, 1, 1, 2 },
            { 2, 1, 1, 1, 1, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 1, 1, 2 },
            { 2, 2, 2, 2, 2, 2, 1, 2 },
            { 5, 1, 1, 1, 1, 1, 1, 3 }
        };

        Stack<char> Texas=new Stack<char>();
        public toPostFix(StringBuilder or)
        {
            origin = or;
            if (preparation()!=-1)
            implementation(); 
        }
        sbyte preparation()  //-1 error
        {
            origin.Append('~');
            origin.Insert(0, '~');
            int i = 1;
            if (origin[i] == '-') { origin.Insert(1, '0'); i++; } else i = 1;
            while (i++ < origin.Length - 1)
            {
                if (origin[i] == '-')
                {
                    if (origin[i - 1] == '/')
                    {
                        origin.Insert(i++, '('); //inserts () if /-x is met
                        int j;
                        for (j = i + 1; digits.Contains(origin[j]); j++);
                        origin.Insert(j, ')');
                    } 
                    if (origin[i - 1] == '(')
                    {
                        origin.Insert(i, '0');
                        i += 2;
                    }
                        else
                    if (symbols.Contains(origin[i - 1]))
                    {
                        Console.WriteLine("Ошибка! Проверь свою запись!");
                        return -1;
                    }
                }
                    
                /*if ((digits.Contains(origin[i])) &&
                    (!digits.Contains(origin[i + 1])) &&
                    (!symbols.Contains(origin[i + 1])))
                { origin.Insert(i + 1, '*'); i++; };*/
                if (origin[i] == '.') origin[i] = ',';
            }
            Console.WriteLine(this.origin);
            return 0;
            
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
            bool exit = false; bool prevletter = false;
            action1(0);
            while (!exit)
            {
                char cur = origin[0];
                if (!symbols.Contains(cur)) 
                { 
                    action0(0); 
                    prevletter = true; 
                }
                else
                {
                    if (prevletter)  // inserts separator
                    {
                        prevletter = false;
                        origin.Insert(0, '&');
                        action0(0); 
                    }
                    int a = symbols.IndexOf(Texas.Peek());
                    int b = symbols.IndexOf(cur);
                    switch (progr[a, b])
                    {
                        case 1:
                            action1(0);
                            break;
                        case 2:
                            action2();
                            break;
                        case 3:
                            action3(0);
                            break;
                        case 5:
                            Console.WriteLine("Ошибка! Проверь свою запись!");
                            exit = true;
                            break;
                        case 4:
                            Console.WriteLine(newstring);
                            exit = true;
                            break;
                    }

                }
            }
        }
    }
}
