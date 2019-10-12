using System.Collections;
using System.Collections.Generic;
using Training_Ex4.Models;
namespace Training_Ex4.Services
{
    public interface IClass
    {
        IEnumerable<Class> GetClass();
        Class GetClassByID(int ID);
        Class InsertClass(Class St);
        void DeleteClass(int ID);
        void UpdateClass(Class StChanges);
        void Save();
    }
}