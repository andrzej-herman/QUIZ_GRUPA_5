using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        Random _random;

        public Backend()
        {
            _random = new Random();       
            UtworzBazePytan();
            Kategorie = BazaPytan!.Select(p => p.Kategoria).Distinct().OrderBy(p => p).ToList();
            AktualnaKategoria = Kategorie[AktualnyIndexKategorii];
        }

        public int AktualnyIndexKategorii { get; set; }
        public List<int> Kategorie { get; set; }
        public List<Pytanie> BazaPytan { get; set; }
        public int AktualnaKategoria { get; set; }
        public Pytanie AktualnePytanie { get; set; }


        public void UtworzBazePytan()
        {
            var sciezka = $"{Directory.GetCurrentDirectory()}\\questions_pl.json";
            var text = File.ReadAllText(sciezka);
            var jso = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            BazaPytan = JsonSerializer.Deserialize<List<Pytanie>>(text)!;
        }

        public void WylosujPytanie()
        {
            var pytaniaZAktualnejKategorii = BazaPytan.Where(p => p.Kategoria == AktualnaKategoria).ToList();
            var liczbaLosowa = _random.Next(0, pytaniaZAktualnejKategorii.Count);
            var wylosowaniePytanie = pytaniaZAktualnejKategorii[liczbaLosowa];
            wylosowaniePytanie.Odpowiedzi = wylosowaniePytanie.Odpowiedzi.OrderBy(p => _random.Next()).ToList();

            int id = 1;
            wylosowaniePytanie.Odpowiedzi.ForEach(p => p.Id = id++);
            AktualnePytanie = wylosowaniePytanie;
        }

        public bool SprawdzPoprawnoscOdpowiedzi(int odpowiedzGracza)
        {
            var wybranaOdpowiedz = AktualnePytanie.Odpowiedzi
                .FirstOrDefault(x => x.Id == odpowiedzGracza);

            if (wybranaOdpowiedz != null)
            {
                return wybranaOdpowiedz.CzyPoprawna;
            }
            else
                return false;
                
        }

        public bool SprawdzCzyGracDalejIPodniesKategorie()
        {
            var maksymalnyIndexKategorii = Kategorie.Count - 1;
            if (AktualnyIndexKategorii == maksymalnyIndexKategorii)
                return false;
            else
            {
                AktualnyIndexKategorii++;
                AktualnaKategoria = Kategorie[AktualnyIndexKategorii];
                return true;    
            }
        }
    }
}
