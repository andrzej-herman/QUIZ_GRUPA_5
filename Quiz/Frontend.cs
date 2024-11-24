using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public static class Frontend
    {
        private static List<string> dopusczalneKlawisze = ["1", "2", "3", "4"];


        public static void PokazEkranPowitalny()
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

        public static int WyswietlPytanieIPobierzOdpowiedzGracza(Pytanie pytanie)
        {
            var nacisnietyKlawisz = WyswietlPytanie(pytanie);
            while(!CzyGraczNacisnalWlasciwyKlawisz(nacisnietyKlawisz))
            {
                nacisnietyKlawisz = WyswietlPytanie(pytanie);
            }

            return int.Parse(nacisnietyKlawisz!);
        }

        public static void ZakonczGre()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Niestety, to nie jest prawidłowa odpowiedź");
            Console.WriteLine();
            Console.WriteLine(" KONIEC GRY");
        }

        public static void DobraOdpowiedz(int kategoria)
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Brawo, to prawidłowa odpowiedź");
            Console.WriteLine($" Zdobywasz {kategoria} pkt.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Write(" Naciśnij ENTER, aby zobaczyć następne pytanie...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static void UkonczonoQuiz()
        {
            Console.Clear();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Brawo, to prawidłowa odpowiedź");
            Console.WriteLine();
            Console.WriteLine(" Udało Ci się ukończyć cały quiz.");
            Console.WriteLine();
            Console.WriteLine(" GRATULACJE !!!");
        }

        private static string? WyswietlPytanie(Pytanie pytanie)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($" Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine($" {pytanie.Tresc}");
            Console.WriteLine();
            foreach (var odpowiedz in pytanie.Odpowiedzi)
            {
                Console.WriteLine($" {odpowiedz.Id}. {odpowiedz.Tresc}");
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" Naciśnij 1, 2, 3 lub 4 aby wybrać odpowiedź ... ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        private static bool CzyGraczNacisnalWlasciwyKlawisz(string? klawisz)
        {
            var result = false;
            if (!string.IsNullOrWhiteSpace(klawisz))
            {
                if (dopusczalneKlawisze.Contains(klawisz))
                    result = true;
            }
            return result;
        }
    }
}
