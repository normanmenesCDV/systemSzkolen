using System.Linq.Expressions;
using Application.DTO;
using Domain.SzkolenieAggregate;
using Infrastructure.Data.Repositories;

namespace Application.SzkolenieCRUD.Get
{
    public class GetSzkolenieQuery
    {
        private UnitOfWork _uow = null;

        public GetSzkolenieQuery()
        {
            _uow = new UnitOfWork();
        }

        public List<SzkolenieDTO> GetSzkolenieDTO(
            Expression<Func<Szkolenie, bool>> predicate = null
        )
        {
            var szkolenia = getSzkolenie(predicate);
            return szkolenia.ConvertAll(szkolenie => SzkolenieHelper.EntityToDTO(szkolenie));
        }

        private List<Szkolenie> getSzkolenie(Expression<Func<Szkolenie, bool>> predicate = null)
        {
            var szkolenia = _uow.SzkolenieRepository.GetOverview(predicate);
            return szkolenia.ToList();
        }

        public SzkolenieDTO GetSzkolenieDTO(int id)
        {
            var szkolenie = getSzkolenie(id);
            return SzkolenieHelper.EntityToDTO(szkolenie);
        }

        private Szkolenie? getSzkolenie(int id)
        {
            return _uow.SzkolenieRepository.GetDetail(x => x.Id == id);
        }
    }
}
