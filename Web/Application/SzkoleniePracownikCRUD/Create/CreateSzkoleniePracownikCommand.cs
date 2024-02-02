using Application.DTO;
using Application.PracownikCRUD;
using Infrastructure.Data.Repositories;

namespace Application.SzkoleniePracownikCRUD.Create
{
    public class CreateSzkoleniePracownikCommand
    {
        private UnitOfWork _uow = null;

        public CreateSzkoleniePracownikCommand()
        {
            _uow = new UnitOfWork();
        }

        public int CreateSzkoleniePracownik(SzkoleniePracownikDTO szkoleniePracownikDTO)
        {
            var szkoleniePracownik = SzkoleniePracownikHelper.DTOToEntity(szkoleniePracownikDTO);
            _uow.SzkoleniePracownikRepository.Add(szkoleniePracownik);
            _uow.SaveChanges();
            return szkoleniePracownik.SzkolenieId;
        }
    }
}
