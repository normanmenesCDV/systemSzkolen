namespace Application.DTO
{
    public class PracownikDTO
    {
        public int? Id { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Plec { get; set; }
        public string? DataUrodzenia { get; set; }
        public string? PESEL { get; set; }
        public string? Uwagi { get; set; }

        public List<SzkoleniePracownikDTO>? Szkolenia { get; set; }
    }
}
