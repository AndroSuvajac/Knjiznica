using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Library blabla = new Library();
        string biraj;

        do
        {
            Console.WriteLine("Knjižnični sustav");
            Console.WriteLine("1. Dodaj knjigu");
            Console.WriteLine("2. Dodaj korisnika");
            Console.WriteLine("3. Posudi knjigu");
            Console.WriteLine("4. Vrati knjigu");
            Console.WriteLine("5. Izađi");

            biraj = Console.ReadLine();

            switch (biraj)
            {
                case "1":
                    Console.Write("Unesite naslov knjige: ");
                    string naziv_knjige = Console.ReadLine();
                    blabla.AddBook(naziv_knjige);
                    break;
                case "2":
                    Console.Write("Unesite ime korisnika: ");
                    string naziv_korisnika = Console.ReadLine();
                    blabla.AddUser(naziv_korisnika);
                    break;
                case "3":
                    Console.Write("Unesite ID knjige koju želite posuditi: ");
                    int IdKnjige = int.Parse(Console.ReadLine());
                    Console.Write("Unesite ID korisnika koji posuđuje knjigu: ");
                    int IdKorisnika = int.Parse(Console.ReadLine());
                    blabla.BorrowBook(IdKnjige, IdKorisnika);
                    break;
                case "4":
                    Console.Write("Unesite ID knjige koju vraćate: ");
                    IdKnjige = int.Parse(Console.ReadLine());
                    blabla.ReturnBook(IdKnjige);
                    break;
                case "5":
                    break;
                default:
                    Console.WriteLine("Ako pisu brojevi od 1 do 5, onda stisni broj od 1 do 5! -_-");
                    break;
            }
        } while (biraj != "5");
    }
}

class Book
{
    public int Id { get; }
    public string Naziv { get; }
    public bool Posudjena { get; set; }

    public Book(int id, string naziv)
    {
        Id = id;
        Naziv = naziv;
        Posudjena = false;
    }
}

class User
{
    public int Id { get; }
    public string Ime { get; }

    public User(int id, string ime)
    {
        Id = id;
        Ime = ime;
    }
}

class Library
{
    private List<Book> books = new List<Book>();
    private List<User> users = new List<User>();

    public void AddBook(string naziv)
    {
        int id = books.Count + 1;
        Book knjiga = new Book(id, naziv);
        books.Add(knjiga);
        Console.WriteLine($"Knjiga dodana: {naziv} (ID: {id})");
    }

    public void AddUser(string ime)
    {
        int id = users.Count + 1;
        User korisnik = new User(id, ime);
        users.Add(korisnik);
        Console.WriteLine($"Korisnik dodan: {ime} (ID: {id})");
    }

    public void BorrowBook(int IdKnjige, int IdKorisnika)
    {
        Book knjiga = books.Find(b => b.Id == IdKnjige);
        User korisnik = users.Find(u => u.Id == IdKorisnika);

        if (knjiga != null && korisnik != null && !knjiga.Posudjena)
        {
            knjiga.Posudjena = true;
            Console.WriteLine($"{korisnik.Ime} je posudio knjigu: {knjiga.Naziv}");
        }
        else
        {
            Console.WriteLine("Knjiga ili korisnik nisu pronađeni ili je knjiga već posuđena.");
        }
    }

    public void ReturnBook(int IdKnjige)
    {
        Book knjiga = books.Find(b => b.Id == IdKnjige);

        if (knjiga != null && knjiga.Posudjena)
        {
            knjiga.Posudjena = false;
            Console.WriteLine($"Knjiga je vraćena: {knjiga.Naziv}");
        }
        else
        {
            Console.WriteLine("Knjiga nije pronađena ili nije posuđena.");
        }
    }
}
