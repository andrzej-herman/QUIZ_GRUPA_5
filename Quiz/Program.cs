using Quiz;


// Tworzenie obiektu backend
var backend = new Backend();

// tworzenie bazy pytań => W Konstruktorze
// ustawianie kategorii na najniższą  => W Konstruktorze

// wyswietlanie ekranu powitalnego
Frontend.PokazEkranPowitalny();

// losowanie pytania
backend.WylosujPytanie();

// wyswietlanie pytania
var odpowiedzGracza = Frontend.WyswietlPytanieIPobierzOdpowiedzGracza(backend.AktualnePytanie);

// walidacja odpowiedzi gracza
var czyPoprawnaOdpowiedz = backend.SprawdzPoprawnoscOdpowiedzi(odpowiedzGracza);

if (czyPoprawnaOdpowiedz)
{

    Frontend.DobraOdpowiedz(backend.AktualnaKategoria);
}
else
{
    Frontend.ZakonczGre();
}


Console.ReadLine();