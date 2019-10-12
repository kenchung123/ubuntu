using System;
using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Services;
using Example_04.Repository;
namespace Example_04.UnitOfWork
{
    public interface IUnitOfWork  : IDisposable
    {
        IGenericRepository<Student> StudentRepository { get; }
        IGenericRepository<Class>  ClassRepository { get; set; }
        void Save();
    }
}