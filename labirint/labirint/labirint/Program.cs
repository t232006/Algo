using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labirint
{
    class Program
    {
        
        static void Main(string[] args)
        {
            TCreator cre1 = new TCreator(49,19,1,1);
            /*cre1.printMap();
            #region save
            Console.WriteLine("Сохранить?\n y - да\n n - нет");
            Char c = Console.ReadKey().KeyChar;
            if (c == 'y') Console.WriteLine("Введите имя файла");
            string filename_=Console.ReadLine();
            #endregion
            cre1.SaveMap(filename_);*/
            cre1.LoadMap("map\\проба 49X19.txt");
            cre1.printMap();
        }
    }
}
