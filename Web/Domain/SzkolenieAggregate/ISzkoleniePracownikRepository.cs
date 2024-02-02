using System.Linq.Expressions;

namespace Domain.SzkolenieAggregate
{
    public interface ISzkoleniePracownikRepository
    {
        void Add(SzkoleniePracownik entity);

        void Delete(SzkoleniePracownik entity);

        SzkoleniePracownik? GetDetail(Expression<Func<SzkoleniePracownik, bool>> predicate);

        IEnumerable<SzkoleniePracownik> GetOverview(
            Expression<Func<SzkoleniePracownik, bool>> predicate = null
        );
    }
}
