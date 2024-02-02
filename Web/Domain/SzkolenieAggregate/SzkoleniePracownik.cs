using Domain.PracownikAggregate;

namespace Domain.SzkolenieAggregate
{
    public class SzkoleniePracownik
    {
        public int SzkolenieId { get; set; }
        public int PracownikId { get; set; }
        public decimal? WynikWProc { get; set; }

        public Szkolenie Szkolenie { get; set; }
        public Pracownik Pracownik { get; set; }

        public SzkoleniePracownik(int szkolenieId, int pracownikId, decimal? wynikWProc)
        {
            SzkolenieId = szkolenieId;
            PracownikId = pracownikId;
            WynikWProc = wynikWProc;
        }
    }
}
