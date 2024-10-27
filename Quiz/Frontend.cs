using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Frontend
    {
        public void PokazEkranPowitalny()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(" WITAJ W APLIKACJI QUIZ");
            Console.WriteLine();
            Console.WriteLine(" SPRÓBUJ ODPOWIEDZIEĆ NA 7 PYTAŃ - WÓWCZAS WYGRASZ QUIZ");
            Console.WriteLine();
            Console.WriteLine(" POWODZENIA !!!");
            Console.WriteLine();
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.Write(" Naciśnij ENTER, aby rozpocząć grę ...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
    }
}
