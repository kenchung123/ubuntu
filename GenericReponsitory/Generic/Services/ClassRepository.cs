using System.Collections.Generic;
using Example_04.Models;

namespace Example_04.Services
{
    public class ClassRepository : IClass
    {
        private readonly SChoolDbContext _contex;
        public ClassRepository(SChoolDbContext context)
        {
            _contex = context;
        }
        public IEnumerable<Class> GetClass()
        {
            return _contex.Classes;
        }

        public Class GetById(int? id)
        {
            return _contex.Classes.Find(id);     
        }
        public void InsertClass(Class classes)
        {
            _contex.Classes.Add(classes);
            _contex.SaveChanges();
        }

        public void DeleteClass(int id)
        {
            Class classes = _contex.Classes.Find(id);
            _contex.Classes.Remove(classes);
        }

        public void UpdateClass(Class classes)
        {
            _contex.Classes.Update(classes);
            _contex.SaveChanges();
        }

        public void Save()
        {
            _contex.SaveChanges();
        }
    }
}