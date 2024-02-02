using Application.DTO;
using Infrastructure.Data.Repositories;

namespace Application.SzkolenieCRUD.Update
{
    public class UpdateSzkolenieCommand
    {
        private UnitOfWork _uow = null;

        public UpdateSzkolenieCommand()
        {
            _uow = new UnitOfWork();
        }

        public void UpdateSzkolenie(int id, SzkolenieDTO szkolenieDTO)
        {
            var szkolenie = _uow.SzkolenieRepository.GetDetail(x => id == x.Id);
            if (szkolenie == null)
            {
                throw new Exception("Podane szkolenie nie istnieje");
            }

            DateOnly.TryParse(szkolenieDTO.DataRozpoczecia, out var dataRozpoczecia);
            DateOnly.TryParse(szkolenieDTO.DataZakonczenia, out var dataZakonczenia);

            szkolenie.Nazwa = szkolenieDTO.Nazwa;
            szkolenie.Organizator = szkolenieDTO.Organizator;
            szkolenie.DataRozpoczecia = dataRozpoczecia;
            szkolenie.DataZakonczenia = dataZakonczenia;
            szkolenie.Uwagi = szkolenieDTO.Uwagi;

            _uow.SaveChanges();
        }
    }
}
