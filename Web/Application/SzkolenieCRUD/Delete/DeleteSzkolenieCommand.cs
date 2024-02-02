using Infrastructure.Data.Repositories;

namespace Application.SzkolenieCRUD.Delete
{
    public class DeleteSzkolenieCommand
    {
        private UnitOfWork _uow = null;

        public DeleteSzkolenieCommand()
        {
            _uow = new UnitOfWork();
        }

        public void DeleteSzkolenie(int id)
        {
            var szkolenie = _uow.SzkolenieRepository.GetDetail(x => id == x.Id);
            if (szkolenie == null)
            {
                throw new Exception("Podane szkolenie nie istnieje");
            }

            _uow.SzkolenieRepository.Delete(szkolenie);

            _uow.SaveChanges();
        }
    }
}
