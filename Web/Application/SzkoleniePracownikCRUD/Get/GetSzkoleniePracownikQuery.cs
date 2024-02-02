using System.Linq.Expressions;
using Application.DTO;
using Application.PracownikCRUD;
using Domain.PracownikAggregate;
using Domain.SzkolenieAggregate;
using Infrastructure.Data.Repositories;

namespace Application.SzkoleniePracownikCRUD.Get
{
    public class GetSzkoleniePracownikQuery
    {
        private UnitOfWork _uow = null;

        public GetSzkoleniePracownikQuery()
        {
            _uow = new UnitOfWork();
        }

        public List<SzkoleniePracownikDTO> GetSzkoleniaPracownicyDTO(
            Expression<Func<SzkoleniePracownik, bool>> predicate = null
        )
        {
            var szkoleniePracownicy = getSzkoleniaPracownicy(predicate);
            return szkoleniePracownicy.ConvertAll(
                szkoleniePracownik => SzkoleniePracownikHelper.EntityToDTO(szkoleniePracownik)
            );
        }

        private List<SzkoleniePracownik> getSzkoleniaPracownicy(
            Expression<Func<SzkoleniePracownik, bool>> predicate = null
        )
        {
            var szkoleniaPracownicy = _uow.SzkoleniePracownikRepository.GetOverview(predicate);
            return szkoleniaPracownicy.ToList();
        }

        public SzkoleniePracownikDTO GetSzkoleniePracownikDTO(int szkolenieId, int pracownikId)
        {
            var szkoleniePracownik = getSzkoleniePracownik(szkolenieId, pracownikId);
            return SzkoleniePracownikHelper.EntityToDTO(szkoleniePracownik);
        }

        private SzkoleniePracownik? getSzkoleniePracownik(int szkolenieId, int pracownikId)
        {
            return _uow.SzkoleniePracownikRepository.GetDetail(
                x => x.SzkolenieId == szkolenieId && x.PracownikId == pracownikId
            );
        }
    }
}
