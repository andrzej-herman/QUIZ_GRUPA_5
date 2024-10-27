using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public List<Pytanie> BazaPytan { get; set; }
        public int AktualnaKategoria { get; set; }

        public void UtworzBazePytan()
        {
            BazaPytan = new List<Pytanie>();
            Pytanie p1 = new Pytanie();
            p1.Id = 1;
            p1.Kategoria = 100;
            p1.Tresc = "Jak miał na imię Einstein?";
            p1.Odpowiedz_1 = "Albert";
            p1.Odpowiedz_2 = "Aaron";
            p1.Odpowiedz_3 = "Anthony";
            p1.Odpowiedz_4 = "Aragon";
            BazaPytan.Add(p1);

            Pytanie p2 = new Pytanie();
            p2.Id = 2;
            p2.Kategoria = 200;
            p2.Tresc = "W którym roku wybuchła I wojna światowa?";
            p2.Odpowiedz_1 = "1914";
            p2.Odpowiedz_2 = "1918";
            p2.Odpowiedz_3 = "1945";
            p2.Odpowiedz_4 = "2014";
            BazaPytan.Add(p2);

            Pytanie p3 = new Pytanie();
            p3.Id = 3;
            p3.Kategoria = 300;
            p3.Tresc = "Jaki jest symbol chemiczny żelaza?";
            p3.Odpowiedz_1 = "Fe";
            p3.Odpowiedz_2 = "H";
            p3.Odpowiedz_3 = "Ca";
            p3.Odpowiedz_4 = "P";
            BazaPytan.Add(p3);
        }

    }
}
