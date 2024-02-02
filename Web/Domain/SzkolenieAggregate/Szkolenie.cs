namespace Domain.SzkolenieAggregate
{
    public class Szkolenie
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Nazwa { get; set; }
        public string? Organizator { get; set; }
        public DateOnly? DataRozpoczecia { get; set; }
        public DateOnly? DataZakonczenia { get; set; }
        public string? Uwagi { get; set; }

        public ICollection<SzkoleniePracownik>? SzkoleniaPracownicy { get; set; }

        public Szkolenie(
            string nazwa,
            string? organizator,
            DateOnly? dataRozpoczecia,
            DateOnly? dataZakonczenia,
            string? uwagi
        )
        {
            Nazwa = nazwa;
            Organizator = organizator;
            DataRozpoczecia = dataRozpoczecia;
            DataZakonczenia = dataZakonczenia;
            Uwagi = uwagi;
        }
    }
}
