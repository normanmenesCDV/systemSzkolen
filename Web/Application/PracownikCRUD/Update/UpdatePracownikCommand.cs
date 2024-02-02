using Application.DTO;
using Infrastructure.Data.Repositories;

namespace Application.PracownikCRUD.Update
{
    public class UpdatePracownikCommand
    {
        private UnitOfWork _uow = null;

        public UpdatePracownikCommand()
        {
            _uow = new UnitOfWork();
        }

        public void UpdatePracownik(int id, PracownikDTO pracownikDTO)
        {
            var pracownik = _uow.PracownikRepository.GetDetail(x => id == x.Id);
            if (pracownik == null)
            {
                throw new Exception("Podany pracownik nie istnieje");
            }

            DateOnly.TryParse(pracownikDTO.DataUrodzenia, out var dataUrodzenia);

            pracownik.Imie = pracownikDTO.Imie;
            pracownik.Nazwisko = pracownikDTO.Nazwisko;
            pracownik.Plec = pracownikDTO.Plec[0];
            pracownik.DataUrodzenia = dataUrodzenia;
            pracownik.PESEL = pracownikDTO.PESEL;
            pracownik.Uwagi = pracownikDTO.Uwagi;

            _uow.SaveChanges();
        }
    }
}
