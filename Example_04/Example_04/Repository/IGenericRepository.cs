using System.Collections.Generic;
using Example_04.Models;

namespace Example_04.Repository
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> Get();
        TEntity GetById(int? id);
        void Insert(TEntity  tentity);
        void Delete(int id);
        void Update(TEntity tentity);
        void Save();
    }
}