using System.Text.Json;


namespace Quiz.Data
{
    public class GameService
    {
        private Random? _random;
        private List<Question>? _bazaPytan;
        private int _aktualnyIndexKategorii;
        private List<int>? _kategorie;

        public GameService()
        {
            _random = new Random();       
            UtworzBazePytan();
            StworzKategorie();
            AktualnaKategoria = _kategorie![_aktualnyIndexKategorii];
        }

        public int AktualnaKategoria { get; set; }
        public Question? AktualnePytanie { get; set; }
        public void WylosujPytanie()
        {
            var pytaniaZAktualnejKategorii = _bazaPytan!.Where(p => p.Category == AktualnaKategoria).ToList();
            var liczbaLosowa = _random!.Next(0, pytaniaZAktualnejKategorii.Count);
            var wylosowaniePytanie = pytaniaZAktualnejKategorii[liczbaLosowa];
            wylosowaniePytanie.Answers = wylosowaniePytanie.Answers!.OrderBy(p => _random.Next()).ToList();

            int id = 1;
            wylosowaniePytanie.Answers.ForEach(p => p.Id = id++);
            AktualnePytanie = wylosowaniePytanie;
        }
        public bool SprawdzPoprawnoscOdpowiedzi(int odpowiedzGracza)
        {
            var wybranaOdpowiedz = AktualnePytanie!.Answers!
                .FirstOrDefault(x => x.Id == odpowiedzGracza);

            if (wybranaOdpowiedz != null)
            {
                return wybranaOdpowiedz.IsCorrect;
            }
            else
                return false;

        }
        public bool SprawdzCzyGracDalejIPodniesKategorie()
        {
            var maksymalnyIndexKategorii = _kategorie!.Count - 1;
            if (_aktualnyIndexKategorii == maksymalnyIndexKategorii)
                return false;
            else
            {
                _aktualnyIndexKategorii++;
                AktualnaKategoria = _kategorie[_aktualnyIndexKategorii];
                return true;
            }
        }

        private void StworzKategorie()
        {
            _kategorie = _bazaPytan!.Select(p => p.Category).Distinct().OrderBy(p => p).ToList();
        }
        private void UtworzBazePytan()
        {
            var sciezka = $"{Directory.GetCurrentDirectory()}\\questions.json";
            var text = File.ReadAllText(sciezka);
            var jso = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _bazaPytan = JsonSerializer.Deserialize<List<Question>>(text)!;
        }
        
    }
}
