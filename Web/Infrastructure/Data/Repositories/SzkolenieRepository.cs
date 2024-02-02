using System.Linq.Expressions;
using Domain.SzkolenieAggregate;

namespace Infrastructure.Data.Repositories
{
    public class SzkolenieRepository : ISzkolenieRepository
    {
        private Model _db;

        public SzkolenieRepository(Model context)
        {
            _db = context;
        }

        public void Add(Szkolenie entity)
        {
            _db.Szkolenia.Add(entity);
        }

        public void Delete(Szkolenie entity)
        {
            _db.Szkolenia.Remove(entity);
        }

        public Szkolenie? GetDetail(Expression<Func<Szkolenie, bool>> predicate)
        {
            return _db.Szkolenia.FirstOrDefault(predicate);
        }

        public IEnumerable<Szkolenie> GetOverview(
            Expression<Func<Szkolenie, bool>> predicate = null
        )
        {
            if (predicate == null)
            {
                return _db.Szkolenia.ToList();
            }
            return _db.Szkolenia.Where(predicate).ToList();
        }
    }
}
