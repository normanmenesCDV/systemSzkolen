using Application.DTO;
using Domain.PracownikAggregate;
using Domain.SzkolenieAggregate;
using Infrastructure.Data.Repositories;

namespace Application.PracownikCRUD.Update
{
    public class UpdateSzkoleniePracownikCommand
    {
        private UnitOfWork _uow = null;

        public UpdateSzkoleniePracownikCommand()
        {
            _uow = new UnitOfWork();
        }

        public void UpdateSzkoleniePracownikWynik(SzkoleniePracownikDTO szkoleniePracownikDTO)
        {
            var szkoleniePracownik = _uow.SzkoleniePracownikRepository.GetDetail(
                x =>
                    x.SzkolenieId == szkoleniePracownikDTO.SzkolenieId
                    && x.PracownikId == szkoleniePracownikDTO.PracownikId
            );
            if (szkoleniePracownik == null)
            {
                throw new Exception("Podane szkolenie dla pracownika nie istnieje");
            }

            szkoleniePracownik.WynikWProc = szkoleniePracownikDTO.WynikWProc;

            _uow.SaveChanges();
        }
    }
}
