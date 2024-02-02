using System.Linq.Expressions;
using Domain.SzkolenieAggregate;

namespace Infrastructure.Data.Repositories
{
    public class SzkoleniePracownikRepository : ISzkoleniePracownikRepository
    {
        private Model _db;

        public SzkoleniePracownikRepository(Model context)
        {
            _db = context;
        }

        public void Add(SzkoleniePracownik entity)
        {
            _db.SzkoleniaPracownicy.Add(entity);
        }

        public void Delete(SzkoleniePracownik entity)
        {
            _db.SzkoleniaPracownicy.Remove(entity);
        }

        public SzkoleniePracownik? GetDetail(Expression<Func<SzkoleniePracownik, bool>> predicate)
        {
            return _db.SzkoleniaPracownicy.FirstOrDefault(predicate);
        }

        public IEnumerable<SzkoleniePracownik> GetOverview(
            Expression<Func<SzkoleniePracownik, bool>> predicate = null
        )
        {
            if (predicate == null)
            {
                return _db.SzkoleniaPracownicy.ToList();
            }
            return _db.SzkoleniaPracownicy.Where(predicate).ToList();
        }
    }
}
