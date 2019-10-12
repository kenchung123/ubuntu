using System.Collections.Generic;
using Example_04.Models;

namespace Example_04.Services
{
    public  interface IClass
    {
        IEnumerable<Class> GetClass();
        Class GetById(int? id);
        void InsertClass(Class  classes);
        void DeleteClass(int id);
        void UpdateClass(Class classes);
        void Save();
    }
}