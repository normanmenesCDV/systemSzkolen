using System.Linq.Expressions;

namespace Domain.SzkolenieAggregate
{
    public interface ISzkolenieRepository
    {
        void Add(Szkolenie entity);

        void Delete(Szkolenie entity);

        Szkolenie? GetDetail(Expression<Func<Szkolenie, bool>> predicate);

        IEnumerable<Szkolenie> GetOverview(Expression<Func<Szkolenie, bool>> predicate = null);
    }
}
