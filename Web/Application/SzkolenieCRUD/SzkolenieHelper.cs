using Application.DTO;
using Domain.SzkolenieAggregate;

namespace Application.SzkolenieCRUD
{
    internal class SzkolenieHelper
    {
        internal static Szkolenie DTOToEntity(SzkolenieDTO szkolenieDTO)
        {
            DateOnly.TryParse(szkolenieDTO.DataRozpoczecia, out var dataRozpoczecia);
            DateOnly.TryParse(szkolenieDTO.DataZakonczenia, out var dataZakonczenia);

            return new Szkolenie(
                nazwa: szkolenieDTO.Nazwa,
                organizator: szkolenieDTO.Organizator,
                dataRozpoczecia: dataRozpoczecia,
                dataZakonczenia: dataZakonczenia,
                uwagi: szkolenieDTO.Uwagi
            );
        }

        internal static SzkolenieDTO EntityToDTO(Szkolenie szkolenie) =>
            new SzkolenieDTO
            {
                Id = szkolenie.Id,
                Nazwa = szkolenie.Nazwa,
                Organizator = szkolenie.Organizator,
                DataRozpoczecia = szkolenie.DataRozpoczecia.ToString(),
                DataZakonczenia = szkolenie.DataZakonczenia.ToString(),
                Uwagi = szkolenie.Uwagi
            };
    }
}
