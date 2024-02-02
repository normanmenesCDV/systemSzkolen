using Application.DTO;
using Application.SzkoleniePracownikCRUD;
using Domain.PracownikAggregate;
using Domain.SzkolenieAggregate;

namespace Application.PracownikCRUD
{
    internal class PracownikHelper
    {
        internal static Pracownik DTOToEntity(PracownikDTO pracownikDTO)
        {
            DateOnly.TryParse(pracownikDTO.DataUrodzenia, out var dataUrodzenia);

            return new Pracownik(
                imie: pracownikDTO.Imie,
                nazwisko: pracownikDTO.Nazwisko,
                plec: pracownikDTO.Plec[0],
                dataUrodzenia: dataUrodzenia,
                pESEL: pracownikDTO.PESEL,
                uwagi: pracownikDTO.Uwagi
            );
        }

        internal static PracownikDTO EntityToDTO(Pracownik pracownik) {
            var szkolenia = new List<SzkoleniePracownikDTO>();
            if (pracownik.SzkoleniaPracownicy != null)
            {
                foreach (SzkoleniePracownik szkolenie in pracownik.SzkoleniaPracownicy)
                {
                    szkolenia.Add(SzkoleniePracownikHelper.EntityToDTO(szkolenie));
                }
            }
            
            return new PracownikDTO
            {
                Id = pracownik.Id,
                Imie = pracownik.Imie,
                Nazwisko = pracownik.Nazwisko,
                Plec = pracownik.Plec.ToString(),
                DataUrodzenia = pracownik.DataUrodzenia.ToString(),
                PESEL = pracownik.PESEL,
                Uwagi = pracownik.Uwagi,
                Szkolenia = szkolenia
            };
        }
    }
}
