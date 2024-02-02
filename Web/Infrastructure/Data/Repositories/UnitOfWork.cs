using Domain.PracownikAggregate;
using Domain.SzkolenieAggregate;

namespace Infrastructure.Data.Repositories
{
    public class UnitOfWork
    {
        private Model _db = new Model();

        // Wszystkie repozytoria jako pola
        IPracownikRepository pracownikRepository = null;
        ISzkolenieRepository szkolenieRepository = null;
        ISzkoleniePracownikRepository szkoleniePracownikRepository = null;

        // Gettery dla każdego repozytorium
        public IPracownikRepository PracownikRepository
        {
            get
            {
                if (pracownikRepository == null)
                    pracownikRepository = new PracownikRepository(_db);
                return pracownikRepository;
            }
        }

        public ISzkolenieRepository SzkolenieRepository
        {
            get
            {
                if (szkolenieRepository == null)
                    szkolenieRepository = new SzkolenieRepository(_db);
                return szkolenieRepository;
            }
        }

        public ISzkoleniePracownikRepository SzkoleniePracownikRepository
        {
            get
            {
                if (szkoleniePracownikRepository == null)
                    szkoleniePracownikRepository = new SzkoleniePracownikRepository(_db);
                return szkoleniePracownikRepository;
            }
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
