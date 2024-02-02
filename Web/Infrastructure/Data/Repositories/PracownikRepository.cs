using System.Linq.Expressions;
using Domain.PracownikAggregate;

namespace Infrastructure.Data.Repositories
{
    public class PracownikRepository : IPracownikRepository
    {
        private Model _db;

        public PracownikRepository(Model context)
        {
            _db = context;
        }

        public void Add(Pracownik entity)
        {
            _db.Pracownicy.Add(entity);
        }

        public void Delete(Pracownik entity)
        {
            _db.Pracownicy.Remove(entity);
        }

        public Pracownik? GetDetail(Expression<Func<Pracownik, bool>> predicate)
        {
            return _db.Pracownicy.FirstOrDefault(predicate);
        }

        public IEnumerable<Pracownik> GetOverview(
            Expression<Func<Pracownik, bool>> predicate = null
        )
        {
            if (predicate == null)
            {
                return _db.Pracownicy.ToList();
            }
            return _db.Pracownicy.Where(predicate).ToList();
        }
    }
}
