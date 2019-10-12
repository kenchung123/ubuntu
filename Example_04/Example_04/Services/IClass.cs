using System.Collections.Generic;
using Example_04.Models;
using Example_04.Repository;
namespace Example_04.Services
{

    public interface IClass
    {
        IEnumerable<Class> Get();
        Class GetById(int? id);
        void Insert(Class  classes);
        void Delete(int id);
        void Update(Class classes);
        void Save();
    }
}