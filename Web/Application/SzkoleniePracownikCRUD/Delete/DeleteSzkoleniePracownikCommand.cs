using Infrastructure.Data.Repositories;

namespace Application.SzkoleniePracownikCRUD.Delete
{
    public class DeleteSzkoleniePracownikCommand
    {
        private UnitOfWork _uow = null;

        public DeleteSzkoleniePracownikCommand()
        {
            _uow = new UnitOfWork();
        }

        public void DeleteSzkoleniePracownik(int szkolenieId, int pracownikId)
        {
            var szkoleniePracownik = _uow.SzkoleniePracownikRepository.GetDetail(
                x => x.SzkolenieId == szkolenieId && x.PracownikId == pracownikId
            );
            if (szkoleniePracownik == null)
            {
                throw new Exception("Podane szkolenie przypisane do pracownika nie istnieje");
            }

            _uow.SzkoleniePracownikRepository.Delete(szkoleniePracownik);

            _uow.SaveChanges();
        }
    }
}
