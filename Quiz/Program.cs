using Quiz;

// Tworzenie obiektów frontend i backend
var backend = new Backend();
var frontend = new Frontend();

// tworzenie bazy pytań
backend.UtworzBazePytan();

// ustawianie kategorii na najniższą
backend.AktualnaKategoria = 100;

// wyswietlanie ekranu powitalnego
frontend.PokazEkranPowitalny();








Console.ReadLine();




