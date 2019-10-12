using System.Collections.Generic;
using Example_04.Models;

namespace Example_04.Services
{
    public  interface IStudent
    {    
        IEnumerable<Student> Get();
        Student GetById(int? id);
        void Insert(Student  student);
        void Delete(int id);
        void Update(Student student);
        void Save();
    }
}