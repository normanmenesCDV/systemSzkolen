using System.Linq.Expressions;

namespace Domain.PracownikAggregate
{
    public interface IPracownikRepository
    {
        void Add(Pracownik entity);

        void Delete(Pracownik entity);

        Pracownik? GetDetail(Expression<Func<Pracownik, bool>> predicate);

        IEnumerable<Pracownik> GetOverview(Expression<Func<Pracownik, bool>> predicate = null);
    }
}
