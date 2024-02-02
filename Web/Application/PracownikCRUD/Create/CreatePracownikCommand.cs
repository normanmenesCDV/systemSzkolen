using Application.DTO;
using Infrastructure.Data.Repositories;

namespace Application.PracownikCRUD.Create
{
    public class CreatePracownikCommand
    {
        private UnitOfWork _uow = null;

        public CreatePracownikCommand()
        {
            _uow = new UnitOfWork();
        }

        public int CreatePracownik(PracownikDTO pracownikDTO)
        {
            var pracownik = PracownikHelper.DTOToEntity(pracownikDTO);
            _uow.PracownikRepository.Add(pracownik);
            _uow.SaveChanges();
            return pracownik.Id;
        }
    }
}
