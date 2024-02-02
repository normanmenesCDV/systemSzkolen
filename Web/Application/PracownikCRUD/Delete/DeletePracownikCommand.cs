using Infrastructure.Data.Repositories;

namespace Application.PracownikCRUD.Delete
{
    public class DeletePracownikCommand
    {
        private UnitOfWork _uow = null;

        public DeletePracownikCommand()
        {
            _uow = new UnitOfWork();
        }

        public void DeletePracownik(int id)
        {
            var pracownik = _uow.PracownikRepository.GetDetail(x => id == x.Id);
            if (pracownik == null)
            {
                throw new Exception("Podany pracownik nie istnieje");
            }

            _uow.PracownikRepository.Delete(pracownik);

            _uow.SaveChanges();
        }
    }
}
