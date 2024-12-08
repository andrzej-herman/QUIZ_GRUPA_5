using Quiz;
using Quiz.Data;


// Tworzenie obiektu backend
var backend = new GameService();

// tworzenie bazy pytań => W Konstruktorze
// ustawianie kategorii na najniższą  => W Konstruktorze

// wyswietlanie ekranu powitalnego
Display.PokazEkranPowitalny();

while(true)
{
    // losowanie pytania
    backend.WylosujPytanie();

    // wyswietlanie pytania
    var odpowiedzGracza = Display.WyswietlPytanieIPobierzOdpowiedzGracza(backend.AktualnePytanie);

    // walidacja odpowiedzi gracza
    var czyPoprawnaOdpowiedz = backend.SprawdzPoprawnoscOdpowiedzi(odpowiedzGracza);

    if (czyPoprawnaOdpowiedz)
    {
        Display.DobraOdpowiedz(backend.AktualnaKategoria);
        // SPRAWDZAMY CZY TO BYŁO OSTATNIE PYTANIE
        var czyGracDalej = backend.SprawdzCzyGracDalejIPodniesKategorie();
        if (!czyGracDalej)
        {
            Display.UkonczonoQuiz();
            break;
        }
    }
    else
    {
        Display.ZakonczGre();
        break;
    }
}

Console.ReadLine();