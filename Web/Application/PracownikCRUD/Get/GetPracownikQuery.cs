using System.Linq.Expressions;
using Application.DTO;
using Domain.PracownikAggregate;
using Infrastructure.Data.Repositories;

namespace Application.PracownikCRUD.Get
{
    public class GetPracownikQuery
    {
        private UnitOfWork _uow = null;

        public GetPracownikQuery()
        {
            _uow = new UnitOfWork();
        }

        public List<PracownikDTO> GetPracownicyDTO(
            Expression<Func<Pracownik, bool>> predicate = null
        )
        {
            var pracownicy = getPracownicy(predicate);
            return pracownicy.ConvertAll(pracownik => PracownikHelper.EntityToDTO(pracownik));
        }

        private List<Pracownik> getPracownicy(Expression<Func<Pracownik, bool>> predicate = null)
        {
            var pracownicy = _uow.PracownikRepository.GetOverview(predicate);
            return pracownicy.ToList();
        }

        public PracownikDTO GetPracownikDTO(int id)
        {
            var pracownik = getPracownik(id);
            return PracownikHelper.EntityToDTO(pracownik);
        }

        private Pracownik? getPracownik(int id)
        {
            return _uow.PracownikRepository.GetDetail(x => x.Id == id);
        }
    }
}
