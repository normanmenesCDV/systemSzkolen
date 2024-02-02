using Application.DTO;
using Domain.SzkolenieAggregate;

namespace Application.SzkoleniePracownikCRUD
{
    internal class SzkoleniePracownikHelper
    {
        internal static SzkoleniePracownik DTOToEntity(SzkoleniePracownikDTO szkoleniePracownikDTO)
        {
            return new SzkoleniePracownik(
                szkolenieId: szkoleniePracownikDTO.SzkolenieId ?? 0,
                pracownikId: szkoleniePracownikDTO.PracownikId ?? 0,
                wynikWProc: szkoleniePracownikDTO.WynikWProc
            );
        }

        internal static SzkoleniePracownikDTO EntityToDTO(SzkoleniePracownik szkoleniePracownik) =>
            new SzkoleniePracownikDTO
            {
                SzkolenieId = szkoleniePracownik.SzkolenieId,
                PracownikId = szkoleniePracownik.PracownikId,
                WynikWProc = szkoleniePracownik.WynikWProc
            };
    }
}
