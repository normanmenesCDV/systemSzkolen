using Application.DTO;
using Infrastructure.Data.Repositories;

namespace Application.SzkolenieCRUD.Create
{
    public class CreateSzkolenieCommand
    {
        private UnitOfWork _uow = null;

        public CreateSzkolenieCommand()
        {
            _uow = new UnitOfWork();
        }

        public int CreateSzkolenie(SzkolenieDTO szkolenieDTO)
        {
            var szkolenie = SzkolenieHelper.DTOToEntity(szkolenieDTO);
            _uow.SzkolenieRepository.Add(szkolenie);
            _uow.SaveChanges();
            return szkolenie.Id;
        }
    }
}
