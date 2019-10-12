using System;
using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Services;
using Example_04.Repository;
namespace Example_04.UnitOfWork
{
    public  class UnitOfWork : IUnitOfWork
    {
        private  SChoolDbContext _context;
        public  UnitOfWork(SChoolDbContext context)
        {
            _context = context;
            InitRepositories();
        }
        public IGenericRepository<Student> StudentRepository { get; private set; }
        public IGenericRepository<Class> ClassRepository { get; set; }

        public void Save()
        {
            _context.SaveChanges();
        }

        private void InitRepositories()
        {
            StudentRepository = new GenericRepository<Student>(_context);
            ClassRepository = new GenericRepository<Class>(_context);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}