using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public Backend()
        {
            AktualnaKategoria = 100;
            UtworzBazePytan();
        }

       
        public List<Pytanie> BazaPytan { get; set; }
        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }


        public void UtworzBazePytan()
        {
            BazaPytan = new List<Pytanie>();
            Pytanie p1 = new Pytanie();
            p1.Id = 1;
            p1.Kategoria = 100;
            p1.Tresc = "Jak miał na imię Einstein?";
            p1.Odpowiedzi = new List<Odpowiedz>();
            var o1 = new Odpowiedz();
            o1.Numer = 1;
            o1.Tresc = "Albert";
            o1.CzyPoprawna = true;
            p1.Odpowiedzi.Add(o1);


            var o2 = new Odpowiedz();
            o2.Numer = 2;
            o2.Tresc = "Aaron";
            p1.Odpowiedzi.Add(o2);

            var o3 = new Odpowiedz();
            o3.Numer = 3;
            o3.Tresc = "Andrew";
            p1.Odpowiedzi.Add(o3);

            var o4 = new Odpowiedz();
            o4.Numer = 4;
            o4.Tresc = "Leszek";
            p1.Odpowiedzi.Add(o4);

            BazaPytan.Add(p1);    
        }

        public void WylosujPytanie()
        {
            // symulujemy losowanie
            AktualnePytanie = BazaPytan[0];
        }

        public bool SprawdzPoprawnoscOdpowiedzi(int odpowiedzGracza)
        {
            var wybranaOdpowiedz = AktualnePytanie.Odpowiedzi
                .FirstOrDefault(x => x.Numer == odpowiedzGracza);

            if (wybranaOdpowiedz != null)
            {
                return wybranaOdpowiedz.CzyPoprawna;
            }
            else
                return false;
                
        }
    }
}
