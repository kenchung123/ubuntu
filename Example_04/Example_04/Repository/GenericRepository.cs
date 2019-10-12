using System.Collections.Generic;
using Example_04.Models;

namespace Example_04.Repository
{
    public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity : class
    {
        private SChoolDbContext _context;

        public GenericRepository(SChoolDbContext context)
        {
            _context = context;
        }
        public IEnumerable<TEntity> Get()
        {
            return _context.Set<TEntity>();       
        }
        public TEntity GetById(int? id)
        {
            return _context.Set<TEntity>().Find(id);     
        }
        public void Insert(TEntity tentity)
        {
            _context.Set<TEntity>().Add(tentity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity tentity = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(tentity);
        }

        public void Update(TEntity tentity)
        {
            _context.Set<TEntity>().Update(tentity);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}