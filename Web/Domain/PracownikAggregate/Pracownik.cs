using System.ComponentModel.DataAnnotations;
using Domain.SzkolenieAggregate;

namespace Domain.PracownikAggregate
{
    public class Pracownik
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        [RegularExpression("[KM]")]
        public char Plec { get; set; }
        public DateOnly? DataUrodzenia { get; set; }
        public string? PESEL { get; set; }
        public string? Uwagi { get; set; }

        public ICollection<SzkoleniePracownik>? SzkoleniaPracownicy { get; set; }

        public Pracownik(
            string imie,
            string nazwisko,
            char plec,
            DateOnly? dataUrodzenia,
            string? pESEL,
            string? uwagi
        )
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Plec = plec;
            DataUrodzenia = dataUrodzenia;
            PESEL = pESEL;
            Uwagi = uwagi;
        }
    }
}
